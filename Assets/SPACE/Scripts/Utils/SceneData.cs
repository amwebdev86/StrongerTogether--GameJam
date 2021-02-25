using System;
using System.Collections;
using System.Collections.Generic;
using SPACE.LevelManager;
using SPACE.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPACE.Utils
{
  [CreateAssetMenu(fileName = "SceneDB", menuName = "GalacticBond/Levels/SceneData")]
  public class SceneData : ScriptableObject
  {
    public List<Level> levels = new List<Level>();
    public List<Menu> menus = new List<Menu>();
    public int currentLevelIndex = 1;

    public void LoadLevelAsync(int levelIndex)
    {
      if (levelIndex <= levels.Count)
      {
        //loads the scene
        AsyncOperation operation = SceneManager.LoadSceneAsync($"Gameplay {levelIndex}");
        //AsyncOperation operationPart2 = SceneManager.LoadSceneAsync($"Gameplay {levelIndex}", LoadSceneMode.Additive);
        Debug.Log($"Gameplay {levelIndex} Loading....");

        //pause before going to scene to load needed managers
        operation.allowSceneActivation = false;
       // operationPart2.allowSceneActivation = false;

        if (operation.isDone )
        {
          operation.allowSceneActivation = true;
          //operationPart2.allowSceneActivation = true;
        }
        else
        {
          Debug.LogError("Unable to load level");
        }

      }
      else
      {
        currentLevelIndex = 1;
      }

    }
    public void NextLevel()
    {
      currentLevelIndex++;
      LoadLevelAsync(currentLevelIndex);
    }
    public void RestartLevel()
    {
      LoadLevelAsync(currentLevelIndex);
    }
    public void NewGame()
    {
      LoadLevelAsync(1);
    }
    public void LoadMainMenu()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.MainMenu].sceneName);

    }
    public void LoadPauseMenu()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.PauseMenu].sceneName, LoadSceneMode.Additive);
    }
    public void LoadOptionsMenu()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.OptionsMenu].sceneName, LoadSceneMode.Additive);

    }


  }
}
