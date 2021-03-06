using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SPACE.Players;
using SPACE.Utils;
using SPACE.Aliens;
using UnityEngine.Events;

namespace SPACE.LevelManager
{
  public class LevelHandler : MonoBehaviour
  {

    [Header("----Character Data----")]
    [SerializeField] private FloatReference playerHealth;
    [SerializeField] private FloatReference playerMaxHealth;
    [SerializeField] private FloatReference alienRescuedCount;

    [Header("----Level Data----")]
    [SerializeField] FloatVariable currLevelAlienCount;
    [SerializeField] FloatVariable currlevelScoreVar;



    [Header("----UI Data----")]
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text playerAlienCount;
    [SerializeField] TMP_Text aliensRemainingText;
    [SerializeField] TMP_Text scoreText;
    [Header("----InGame Menus----")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    bool isPaused = false;
    bool stopTime = false;
    private void OnEnable()
    {
      if (Time.timeScale == 0)
        Time.timeScale = 1;

    }
    void Start()
    {


      currLevelAlienCount.Value = FindObjectsOfType<Alien>().Length;
      if (currlevelScoreVar.Value > 0) currlevelScoreVar.Value = 0;
      InitLevelHandler();
      InitHealthBar();
    }
    private void Update()
    {
      // if (Input.GetKeyDown(KeyCode.Escape))
      // {
      //   if (Cursor.lockState == CursorLockMode.Locked)
      //     Cursor.lockState = CursorLockMode.None;
      //   else
      //     Cursor.lockState = CursorLockMode.Locked;
      // }
      if (Input.GetKeyDown(KeyCode.P))
      {
        TogglePause();
      }


      stopTime = TogglePause(isPaused);



      UpdateHealthBar();
      UpdateHUDText();

    }

    private void TogglePause()
    {
      if (isPaused)
      {
        isPaused = false;
        ResumeTime();

      }
      else
      {
        isPaused = true;
        PauseTime();

      }
    }

    //TODO Add SFX . Remove this Event and add in event SO ...
    public void OnJumpSFX()
    {

      // levelData.audioManager.PlayClip(5, levelAudioSource);

    }
    private void PauseTime()
    {
      Time.timeScale = 0;
    }

    private void ResumeTime()
    {
      Time.timeScale = 1;
    }

    private void InitLevelHandler()
    {

      Cursor.lockState = CursorLockMode.Locked;

      aliensRemainingText.text = "Remainig: " + currLevelAlienCount.Value.ToString();
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
        Cursor.lockState = CursorLockMode.Locked;
        //Time.timeScale = 1;
        return false;
      }



    }

    void InitHealthBar()
    {

      healthBar.fillAmount = playerHealth.Value / 100;
      healthBar.color = Color.green;

    }

    void UpdateHealthBar()
    {
      healthBar.fillAmount = playerHealth.Value / 100;

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
      playerAlienCount.text = alienRescuedCount.Value.ToString();
      aliensRemainingText.text = "Remainig: " + currLevelAlienCount.Value.ToString();
      scoreText.text = $"Score: {currlevelScoreVar.Value}";
    }
    public void RemainingAlienCount()
    {
      currLevelAlienCount.Value--;
    }
    public void DisplayGameOver() => gameOverPanel.SetActive(true);

  }
}
