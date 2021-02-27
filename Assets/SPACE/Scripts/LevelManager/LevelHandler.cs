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
    [SerializeField] FloatVariable maxAlienCount;
    [SerializeField] const float storedMaxCount = 3;
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
      if (maxAlienCount.Value <= storedMaxCount)
      {
        maxAlienCount.Value = storedMaxCount;
      }
      InitLevelHandler();
      InitHealthBar();

    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        if (Cursor.lockState == CursorLockMode.Locked)
          Cursor.lockState = CursorLockMode.None;
        else
          Cursor.lockState = CursorLockMode.Locked;
      }
      TogglePauseControl();
      UpdateHealthBar();
      UpdateHUDText();



    }
    private void InitLevelHandler()
    {

      Cursor.lockState = CursorLockMode.Locked;
      currLevelAlienCount.Value = storedMaxCount;
      aliensRemainingText.text = "Remainig: " + currLevelAlienCount.Value.ToString();
    }

    private void TogglePauseControl()
    {
      //TODO PAUSE ISSUE - TIME DOESNT START BACK UP ON RESTART FROM PAUSE.
    }

    bool TogglePause(bool active)
    {

      if (active)
      {
        Cursor.lockState = CursorLockMode.Confined;
        pausePanel.SetActive(active);
        //Time.timeScale = 0;
        return true;
      }
      else
      {
        pausePanel.SetActive(active);
        //Time.timeScale = 1;
        return false;
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
