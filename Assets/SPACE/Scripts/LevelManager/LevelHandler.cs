using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SPACE.Players;
using SPACE.Aliens;
using SPACE.Utils;

namespace SPACE.LevelManager
{
  public class LevelHandler : MonoBehaviour
  {
    //----------Level DATA
    [SerializeField] Level levelData;
    [SerializeField] FloatReference levelScoreReference;
    [SerializeField] FloatReference remainingAliensRef;

    // ------------ Character data;
    // [SerializeField] PlayerData playerData;
    [SerializeField] FloatReference playerScore;
    [SerializeField] FloatReference playerHP;
    [SerializeField] FloatReference playerHPMax;
    [SerializeField] FloatReference playerCurrentAlienCount;


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
      aliens = new List<AlienData>();//TODO
      //gameOverPanel.SetActive(false);
      levelData.InitLevelData();

      InitHealthBar();

    }

    private void Update()
    {
      TogglePauseControl();
      if (Input.GetKeyDown(KeyCode.Z))//TODO DEBUG PURPOSES ONLY
      {
        // playerData.DamagePlayer(10);

      }
      UpdateHealthBar();
      UpdateHUDText();
      // levelData.UpdateScore(playerData.currentScore);
      levelData.UpdateScore(playerScore.Value); //TODO

    }

    private void TogglePauseControl()
    {
      if (Input.GetKeyDown(KeyCode.P))
      {
        if (!isPaused)
        {
          isPaused = true;
          TogglePause();

        }
        else
        {
          isPaused = false;
          TogglePause();

        }

      }
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

      healthBar.fillAmount = playerHP.Value / playerHPMax.Value;
      healthBar.color = Color.green;

    }

    void UpdateHealthBar()
    {
      var newHealthValue = playerHP.Value;
      healthBar.fillAmount = playerHP.Value / playerHP.Value;
      if (healthBar.fillAmount >= .75)
      {
        healthBar.color = Color.green;
      }
      else if (healthBar.fillAmount <= .5f)
      {
        healthBar.color = Color.yellow;
      }
      else if (healthBar.fillAmount <= .25f)
      {
        healthBar.color = Color.red;
      }
    }

    void UpdateHUDText()
    {
      playerAlienCount.text = playerAlienCount.ToString();
      aliensRemainingText.text = remainingAliensRef.Value.ToString();
    }
    public void DisplayGameOver() => gameOverPanel.SetActive(true);
    public void IncreaseRemainingAliensCount() => levelData.IncrementLevelAlienCount();
    public void DecreaseRemainingAliensCount() => levelData.DecrementLevelAlienCount();






  }
}
