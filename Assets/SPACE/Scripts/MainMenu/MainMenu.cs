using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPACE.Menus
{
  public class MainMenu : MonoBehaviour
  {

    public void StartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
      Application.Quit();
    }

  }
}
