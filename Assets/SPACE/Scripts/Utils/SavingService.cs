using LitJson;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace SPACE.Utils
{
    public interface ISaveable
    {
        //Save ID -- unique string identifying the component
        string SaveID { get; }
        //Content that will be written to disk.
        JsonData SavedData { get; }
        /// <summary>
        /// Called when the game is being loaded
        /// </summary>
        /// <param name="data">The data to be read and used. Information to restore previous state.</param>
        void LoadFromData(JsonData data);
    }
    /// <summary>
    
    /// </summary>
    public static class SavingService 
    {
        //const to avoid typos
        const string ACTIVE_SCENE_KEY = "activeScene";
        const string SCENES_KEY = "scenes";
        const string OBJECTS_KEY = "objects";
        const string SAVEID_KEY = "$saveID";//$ is an unexpected character used to avoid any conflicts.
        static UnityEngine.Events.UnityAction<Scene, LoadSceneMode> LoadObjectsAfterSceneLoad;
        /// <summary>
        /// Saves the game, writes it to a file called filename in the apps
        /// persisten data directory.
        /// </summary>
        /// <param name="filename">name of the file to save</param>
        public static void SaveGame(string filename)
        {
            //The data we will write to disc.
           var result = new JsonData();
            //get all monobehaviour and filter out the ones that are not ISaveable.
            var allSaveableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>();
            if(allSaveableObjects.Count() > 0)
            {
                var savedObjects = new JsonData();//stores list of objects.
                //iterate over every object we want to save.
                foreach(var saveableObject in allSaveableObjects)
                {
                    var data = saveableObject.SavedData;
                    if (data.IsObject)
                    {
                        data[SAVEID_KEY] = saveableObject.SaveID;
                        //add to save data collection
                        savedObjects.Add(data);
                    }
                    else
                    {
                        //provides warning we cannot save this object
                        var behaviour = saveableObject as MonoBehaviour;
                        Debug.LogWarning($"{behaviour}'s save data is not a dictionary. The object was not saved {behaviour.name}");
                    }
                }

            }
            else
            {
                //no objects to save
                Debug.LogWarning("Scene did not contain any saveable objects.");
                //grab all active scenes
                var openScenes = new JsonData();
                var sceneCount = SceneManager.sceneCount;
                for(int i = 0; i < sceneCount; i++)
                {
                    var scene = SceneManager.GetSceneAt(i);
                    openScenes.Add(scene.name);
                }
                //store list of open scenes
                result[SCENES_KEY] = openScenes;
                //store name of active scene
                result[ACTIVE_SCENE_KEY] = SceneManager.GetActiveScene().name;
                //write to disk getting the path name
                var outputPath = Path.Combine(Application.persistentDataPath, filename);
                //configure Json writer and pretty print
                var writer = new JsonWriter();
                writer.PrettyPrint = true;
                //convert the save data to json text.
                result.ToJson(writer);

                //write json to disk
                File.WriteAllText(outputPath, writer.ToString());
                //notify where to find the save game
                Debug.Log($"Wrote saved game to {outputPath}");
                //Garbage collecting. Pauses game momentarily
                result = null;
                System.GC.Collect();
            }
        }
        /// <summary>
        /// The LoadGame method reads the file and first loads the scenes that are specified in the saved game. 
        /// After that, it creates and saves the code that restores the state of the objects in the scenes, and adds it to the SceneManager ’s sceneLoaded event. 
        /// The code itself finds all ISaveable MonoBehaviour s, creates a dictionary that maps their Save ID to the object itself, and then uses the loaded object 
        /// data to both find the appropriate object for the data and deliver the data to that object. 
        /// To save the game, you call the SaveGame method on the SavingService class
        /// </summary>
        /// <param name="fileName">file to load data from</param>
        /// <returns>true if load is successful.</returns>
        public static bool LoadGame(string fileName)
        {
            //find the file
            var dataPath = Path.Combine(Application.persistentDataPath, fileName);
            //ensure file exsists
            if (File.Exists(dataPath) == false)
            {
                Debug.Log($"No file exsists at {dataPath}");
                return false;
            }
            //read json
            var text = File.ReadAllText(dataPath);
            var data = JsonMapper.ToObject(text);
            //ensure data was read and is an object aka Json dictionary
            if(data == null || data.IsObject == false)
            {
                Debug.LogWarning($"Data at {dataPath} is not a Json object");
                return false;

            }
            if (!data.ContainsKey("Scenes"))
            {
                Debug.LogWarning($"data at {dataPath} does not contain any scenes");
                return false;
            }
            //grab list of scenes
            var scenes = data[SCENES_KEY];
            int sceneCount = scenes.Count;
            if(sceneCount == 0)
            {
                Debug.LogWarning($"data at {dataPath} did not provide any scenes");
                return false;
            }

            //load all specified scenes
            for(int i = 0; i < sceneCount; i++)
            {
                var scene = (string)scenes[i];
                if(i == 0)
                {
                    //if first scene replace all other scenes
                    SceneManager.LoadScene(scene, LoadSceneMode.Single);
                }
                else
                {
                    //add any other scene additve
                    SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                }
            }
            if (data.ContainsKey(ACTIVE_SCENE_KEY))
            {
                var activeSceneName = (string)data[ACTIVE_SCENE_KEY];
                var activeScene = SceneManager.GetSceneByName(activeSceneName);
                if(activeScene.IsValid() == false)
                {
                    Debug.LogError($"Data at {dataPath} specifies and active scene that does not exist. Stopping Loading here...");
                    return false;
                }
                SceneManager.SetActiveScene(activeScene);
            }
            else
            {
                Debug.LogWarning($"Data at {dataPath} does not specify an active scene");
            }
            //find all objects in the scene and load them
            if (data.ContainsKey(OBJECTS_KEY))
            {
                var objects = data[OBJECTS_KEY];
                LoadObjectsAfterSceneLoad = (scene, LoadSceneMode) =>
                {
                    var allLoadableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToDictionary(o => o.SavedData, o => o);
                    var objectsCount = objects.Count;
                    for (int i = 0; i < objectsCount; i++)
                    {
                        var objectData = objects[i];
                        //get save id from that data
                        var saveID = (string)objectData[SAVEID_KEY];
                        //attempt to find objects in scene with that id
                        if (allLoadableObjects.ContainsKey(saveID))
                        {
                            var loadableObject = allLoadableObjects[saveID];
                            //ask the object to load from this data
                            loadableObject.LoadFromData(objectData);
                        }
                    }
                    //CLEAN UP
                    SceneManager.sceneLoaded -= LoadObjectsAfterSceneLoad;
                    LoadObjectsAfterSceneLoad = null;
                    System.GC.Collect();
                };
                //Register object loading to run after scene loaded
                SceneManager.sceneLoaded += LoadObjectsAfterSceneLoad;

            }
            return true;
        }
    }
}
