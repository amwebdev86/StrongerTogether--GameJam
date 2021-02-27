﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SPACE.Players;
using SPACE.Aliens;
using SPACE.Utils;
using System;

namespace SPACE.LevelManager
{
  public class LevelHandler : MonoBehaviour
  {

    [Header("----Character Data----")]
    [SerializeField] PlayerData player;

    [Header("----Level Data----")]
    [SerializeField] Level levelData;
    [SerializeField] FloatVariable maxAlienCount;
    [SerializeField] const float storedMaxCount = 3;
    [SerializeField] FloatVariable currLevelAlienCount;
    [SerializeField] FloatVariable remainingAliensVar;
    [SerializeField] FloatVariable currlevelScoreVar;



    [Header("----UI Data----")]
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text playerAlienCount;
    [SerializeField] TMP_Text aliensRemainingText;
    [SerializeField] TMP_Text scoreText;
    [Header("----InGame Menus----")]
    [SerializeField] GameObject gameOverPanel;//TODO Change to scene
    [SerializeField] GameObject pausePanel;
    AudioSource levelAudioSource;



    bool isPaused = false;
    bool stopTime = false;
    private void OnEnable()
    {
      if (Time.timeScale == 0)
        Time.timeScale = 1;


    }
    void Start()
    {
      if (levelAudioSource == null)
      {
        levelAudioSource = new GameObject("new AudioManager").AddComponent<AudioSource>();
      }
      //levelAudioSource = GetComponent<AudioSource>();
      if (maxAlienCount.Value <= storedMaxCount)
      {
        maxAlienCount.Value = storedMaxCount;
      }
      if (currlevelScoreVar.Value > 0)
        currlevelScoreVar.Value = 0;
      InitLevelHandler();
      InitHealthBar();
      // levelData.StartMusic(levelAudioSource);

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
      if (Input.GetKeyDown(KeyCode.P))
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


      stopTime = TogglePause(isPaused);



      UpdateHealthBar();
      UpdateHUDText();

    }
    //TODO Add SFX . Remove this Event and add in event SO ...
    public void OnJumpSFX()
    {

      levelData.audioManager.PlayClip(5, levelAudioSource);

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
      levelAudioSource = FindObjectOfType<AudioSource>();
      // levelAudioSource.Stop();
      levelData.StartMusic(levelAudioSource);
      currLevelAlienCount.Value = storedMaxCount;
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
      scoreText.text = $"Score: {currlevelScoreVar.Value}";
    }
    public void DisplayGameOver() => gameOverPanel.SetActive(true);

  }
}
