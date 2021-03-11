using System;
using System.Collections;
using System.Collections.Generic;
using SPACE.Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SPACE.Menus
{
  public class MainMenu : MonoBehaviour
  {
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject loadingInterface;
    [SerializeField] Image loadScreenProgressBar;
    [SerializeField] GameObject optionsMenu;
    Animator animator;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    private void OnEnable()
    {
      animator = GetComponent<Animator>();
      animator.SetBool("MenuActive", true);
    }

    public void StartGame()
    {
      // animator = GetComponent<Animator>();
      // animator.SetBool("MenuActive", true);
      HideMenu();
      ShowLoadingScreen();
      scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1"));
      StartCoroutine(LoadingScreen());
    }
    public void ToggleOptionsMenu()
    {
      if (optionsMenu.activeInHierarchy == false)
      {
        optionsMenu.SetActive(true);
        animator.SetBool("MenuActive", false);
      }
      else
      {
        animator.SetBool("MenuActive", true);
        optionsMenu.SetActive(false);
      }
    }
    public void QuitGame()
    {
      Application.Quit();
    }



    private IEnumerator LoadingScreen()
    {
      float totalProgress = 0;

      for (int i = 0; i < scenesToLoad.Count; ++i)
      {

        while (!scenesToLoad[i].isDone)
        {
          totalProgress += scenesToLoad[i].progress;
          loadScreenProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
          yield return null;

        }


      }
    }

    private void ShowLoadingScreen()
    {
      loadingInterface.SetActive(true);
    }

    private void HideMenu()
    {
      menuCanvas.SetActive(false);
    }



    private void OnDestroy()
    {
      StopAllCoroutines();
    }

  }
}
