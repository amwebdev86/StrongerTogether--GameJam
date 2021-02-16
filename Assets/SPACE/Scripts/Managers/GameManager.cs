using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SPACE.Utils;
using SPACE.Player;

namespace SPACE.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        GameObject[] _systemPrefabs;
        [SerializeField]
        private List<GameObject> _instancedSystemPrefabs;
        [SerializeField]
        PlayerHealth _playerHealth;
       
        private void Awake()
        {
            
            DontDestroyOnLoad(gameObject);
           
        }
        private void Start()
        {
            _instancedSystemPrefabs = new List<GameObject>();
            InstantiateSystemPrefabs();
            if (_instancedSystemPrefabs.Count > 0)
            {
                foreach (GameObject prefab in _instancedSystemPrefabs)
                {
                    DontDestroyOnLoad(prefab);
                }
            }
            SpawnManager.Instance.ActivateGame(true);
            StartCoroutine(SpawnManager.Instance.Spawner());
            _playerHealth = FindObjectOfType<PlayerHealth>();

        }
        private void Update()
        {
          
        
                
                if (Input.GetKeyDown(KeyCode.J))
                {
                    _playerHealth.TakeDamage(10);
                   
                }
            
        }
        /// <summary>
        /// Adds any prefabs in _systemPrefabs to _instancedSystemPrefabs
        /// </summary>
        private void InstantiateSystemPrefabs()
        {
            GameObject prefabInstance;
            for (int i = 0; i < _systemPrefabs.Length; i++)
            {
                prefabInstance = Instantiate(_systemPrefabs[i]);
                _instancedSystemPrefabs.Add(prefabInstance);
            }
           
        }
        /// <summary>
        /// Loads a scene Async. waiting for operation to complete before loading.
        /// </summary>
        /// <param name="levelName"></param>
        public void LoadLevelAsync(string levelName)
        {
            //loads the scene
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
            Debug.Log($"Loading {levelName}....");
            //pause before going to scene to load needed managers
            operation.allowSceneActivation = false;
            
            StartCoroutine(WaitForLoading(operation));
            
        }
        /// <summary>
        /// Waits for async operation to complete allowing scene activation.
        /// </summary>
        /// <param name="operation">Async loading operation</param>
        /// <returns></returns>
        IEnumerator WaitForLoading(AsyncOperation operation)
        {
            while(operation.progress < 0.9f)
            {
                yield return null;
            }

            Debug.Log("Loading Complete");
            
            operation.allowSceneActivation = true;
                //SpawnManager.Instance.ActivateGame(true);
                //StartCoroutine(SpawnManager.Instance.Spawner());
        }
        /// <summary>
        /// Allows scene to be loading on top of level to host any
        /// managers or utilities.
        /// </summary>
        public void LoadLevelAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        /// <summary>
        /// Unload a scene (async)
        /// </summary>
        public void UnloadLevel(string sceneName)
        {
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(sceneName);
            WaitForUnloading(unloadOperation);
        }
        IEnumerator WaitForUnloading(AsyncOperation operation)
        {
            yield return new WaitUntil(() => operation.isDone);
            Resources.UnloadUnusedAssets();
        }
      
        public string PathForSaving(string filename)
        {
            string identifier = SystemInfo.deviceModel;
            Debug.Log($"Device ID: {identifier}");
            string folderToStoreFiles = Application.persistentDataPath;
            string path = System.IO.Path.Combine(folderToStoreFiles, filename);
            if (String.IsNullOrEmpty(path))
            {
                Debug.LogError("No access to save data");
                return null;
            }
            Debug.Log($"Saved file to {path}");
            return path;
            
        }

    }

}