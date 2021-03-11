using System;
using System.Collections;
using System.Collections.Generic;
using SPACE.Sounds;
using SPACE.Utils;
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
    [SerializeField] Animator menuAnimator;
    [SerializeField] GameObject optionsMenu;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    [SerializeField] Slider volumeSlider;



    public void StartGame()
    {
      HideMenu();
      ShowLoadingScreen();
      scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1"));
      StartCoroutine(LoadingScreen());
    }
    public void HideOptionsMenu()
    {
      menuAnimator.SetBool("MenuActive", true);
      optionsMenu.SetActive(false);

    }

    public void ShowOptionsMenu()
    {
      StartCoroutine("OptionsMenuRoutine");
    }
    IEnumerator OptionsMenuRoutine()
    {
      menuAnimator.SetBool("MenuActive", false);

      yield return new WaitForSeconds(0.5f);
      optionsMenu.SetActive(true);
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

    public void QuitGame()
    {
      Application.Quit();
    }
    private void OnDestroy()
    {
      StopAllCoroutines();
    }

  }
}
