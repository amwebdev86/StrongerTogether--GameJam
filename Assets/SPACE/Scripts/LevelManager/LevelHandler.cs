using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SPACE.Players;
using SPACE.Aliens;

namespace SPACE.LevelManager
{
  public class LevelHandler : MonoBehaviour
  {
    //----------DATA
    [SerializeField] Level levelData;
    [SerializeField] PlayerData playerData;
    [SerializeField] List<AlienData> aliens;
    //TODO Add ENEMYDATA REF
    //-------------UI
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text playerAlienCount;
    [SerializeField] TMP_Text aliensRemainingText;
    //--------- IN GAME MENU
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;



    bool isPaused = false;

    void Start()
    {
      gameOverPanel.SetActive(false);
      //pausePanel.SetActive(false);
      playerData.InitHealth();
      InitHealthBar();

    }

    private void Update()
    {
      // InitHealthBar();

      if (Input.GetKeyDown(KeyCode.P))
      {
        if (!isPaused)
        {
          isPaused = true;

        }
        else
        {
          isPaused = false;
        }

      }
      if (Input.GetKeyDown(KeyCode.Z))
      {
        playerData.DamagePlayer(10);

      }
      TogglePause();
      UpdateHealthBar();
    }

    void TogglePause()
    {

      if (isPaused)
      {

        pausePanel.SetActive(isPaused);
        Time.timeScale = 0;
      }
      else
      {
        pausePanel.SetActive(isPaused);
        Time.timeScale = 1;
      }



    }

    void InitHealthBar()
    {

      healthBar.fillAmount = playerData.playerHealthCurrent.Value / playerData.playerHealthMax.Value;
      healthBar.color = Color.green;

    }

    void UpdateHealthBar()
    {
      var newHealthValue = playerData.playerHealthCurrent.Value;
      Debug.Log(newHealthValue.ToString() + " is the new health value");
      healthBar.fillAmount = (float)playerData.playerHealthCurrent.Value / (float)playerData.playerHealthMax.Value;
if(healthBar.fillAmount >= .75){
        healthBar.color = Color.green;
      }
      else if (healthBar.fillAmount <= .5f)
      {
        healthBar.color = Color.yellow;
      }
      else if (healthBar.fillAmount < .25f)
      {
        healthBar.color = Color.red;
      }
    }
    public void DisplayGameOver()
    {
      gameOverPanel.SetActive(true);
    }





  }
}
