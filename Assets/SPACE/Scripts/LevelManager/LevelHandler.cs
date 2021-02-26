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

    [Header("----Character Data----")]
    [SerializeField] PlayerData player;
    //List<Alien> aliensToRescue;
    [Header("----Level Data----")]
    [SerializeField] Level levelData;
    [SerializeField] FloatVariable currLevelAlienCount;
    [SerializeField] FloatVariable remainingAliensVar;
    [SerializeField] FloatVariable currlevelScoreVar;

    // ------------ Character data;
    // [SerializeField] PlayerData playerData;
    // [SerializeField] FloatReference playerScoreRef;
    // [SerializeField] FloatReference playerHPRef;
    // [SerializeField] FloatReference playerHPMaxRef;
    // [SerializeField] FloatReference playerCurrentAlienCountRef;

    [Header("----UI Data----")]
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text playerAlienCount;
    [SerializeField] TMP_Text aliensRemainingText;
    [Header("----InGame Menus----")]
    [SerializeField] GameObject gameOverPanel;//TODO Change to scene
    [SerializeField] GameObject pausePanel;



    bool isPaused = false;

    void Start()
    {
      InitLevelHandler();
      InitHealthBar();

    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        Cursor.lockState = CursorLockMode.None;
      }
      TogglePauseControl();
      UpdateHealthBar();
      UpdateHUDText();

    }
    private void InitLevelHandler()
    {
      Cursor.lockState = CursorLockMode.Locked;
      currLevelAlienCount.Value = levelData.maxAlienCount.Value;
      aliensRemainingText.text = "Remainig: " + currLevelAlienCount.Value.ToString();
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
        Cursor.lockState = CursorLockMode.Confined;
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

      healthBar.fillAmount = player.playerHealthCurrent.Value / player.playerHealthMax.Value;
      healthBar.color = Color.green;

    }

    void UpdateHealthBar()
    {
      healthBar.fillAmount = player.playerHealthCurrent.Value / player.playerHealthMax.Value;

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
      playerAlienCount.text = player.rescuedCount.Value.ToString();
      currLevelAlienCount.Value = levelData.maxAlienCount.Value - player.rescuedCount.Value;
      aliensRemainingText.text = "Remainig: " + currLevelAlienCount.Value.ToString();
    }
    public void DisplayGameOver() => gameOverPanel.SetActive(true);

  }
}
