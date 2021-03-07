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
        AsyncOperation operation = SceneManager.LoadSceneAsync($"Level{levelIndex}");
        Debug.Log($"Level {levelIndex} Loading....");

      }
      else
      {
        currentLevelIndex = 1;
      }

    }
    public void NextLevel()
    {
      currentLevelIndex++;
      Debug.Log($"Attempting to load next level: {currentLevelIndex}");
      LoadLevelAsync(currentLevelIndex);
    }
    public void Resume()
    {
      SceneManager.UnloadSceneAsync(menus[(int)MenuType.PauseMenu].sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
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
    public void LoadCredits()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.Credits].sceneName);

    }
    public void LoadPauseMenu()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.PauseMenu].sceneName, LoadSceneMode.Additive);
    }
    public void LoadOptionsMenu()
    {
      SceneManager.LoadSceneAsync(menus[(int)MenuType.OptionsMenu].sceneName);

    }


  }
}
