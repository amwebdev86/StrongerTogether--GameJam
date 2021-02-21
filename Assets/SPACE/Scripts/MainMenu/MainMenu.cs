using SPACE.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPACE.MainMenu
{
  public class MainMenu : MonoBehaviour
  {

    public void StartGame()
    {
      // SoundManager.Instance.PlaySound(SoundManager.Sound.MENUCLICK);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
      //SoundManager.Instance.PlaySound(SoundManager.Sound.MENUCLICK);

      Application.Quit();
    }

  }
}
