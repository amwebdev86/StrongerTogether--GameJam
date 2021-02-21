using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using SPACE.Utils;
using SPACE.Players;
using SPACE.UI;
using SPACE.Players.Aliens;

namespace SPACE.Managers
{
  public class GameManager : Singleton<GameManager>
  {
    [SerializeField]
    GameObject[] _systemPrefabs;
    [SerializeField]
    private List<GameObject> _instancedSystemPrefabs;
    PlayerHealth _playerHealth;
    public bool gameRunning = true;
    public UnityEvent m_GameOverEvent;
    private int _currentLvlAlienAmount;
    PlayerHUD _playerHUD;
    private void Start()
    {

      _instancedSystemPrefabs = new List<GameObject>();
      InstantiateSystemPrefabs();

      SpawnManager.Instance.ActivateGame(true);
      StartCoroutine(SpawnManager.Instance.Spawner());
      _playerHealth = FindObjectOfType<PlayerHealth>();
      if (m_GameOverEvent == null)
      {
        m_GameOverEvent = new UnityEvent();
      }
      m_GameOverEvent.AddListener(GameOver);
      InitiateHealthBar(_playerHealth.MaxHealth);
      _currentLvlAlienAmount = GetLevelTotalAlienCount();

      _playerHUD = UIManager.Instance.gameObject.GetComponentInChildren<PlayerHUD>();
      _playerHUD.UpdateLevelUI(GetLevelTotalAlienCount(), GetSceneName());



    }
    private void Update()
    {
      _playerHUD.UpdateLevelUI(GetLevelTotalAlienCount(), GetSceneName() + ' ');
      if (GetLevelTotalAlienCount() <= 0)
      {
        GameOver();
      }

    }

    /// <summary>
    /// Sets the HealthBar to the appropriate player HP amount
    /// </summary>
    /// <param name="amount">Player Max HP</param>
    public void InitiateHealthBar(int amount)
    {
      UIManager.Instance.SetInitialHealth(amount);
    }
    /// <summary>
    /// Updates the HealthBar
    /// </summary>
    /// <param name="currentHealth">Player's Current Health</param>
    public void UpdateHealthBar(int currentHealth)
    {
      UIManager.Instance.UpdatePlayerHealth(currentHealth);
    }

    public void UpdatePlayerAlienCount(int value)
    {
      //UIManager.Instance.gameObject.GetComponentInChildren<PlayerHUD>().AlienCountUpdate(value);
      _playerHUD.AlienCountUpdate(value);

    }

    /// <summary>
    /// Adds any prefabs in _systemPrefabs to _instancedSystemPrefabs
    /// </summary>
    private void InstantiateSystemPrefabs()
    {
      GameObject prefabInstance;
      for (int i = 0; i < _systemPrefabs.Length; i++)
      {
        prefabInstance = Instantiate(_systemPrefabs[i]);
        _instancedSystemPrefabs.Add(prefabInstance);
      }

    }

    public int GetLevelTotalAlienCount()
    {
      Alien[] aliensInLevel = FindObjectsOfType<Alien>();
      return aliensInLevel.Length;
    }
    public void DamagePlayer(int amount)
    {
      _playerHealth.TakeDamage(amount);
    }

    /// <summary>
    /// When the player reaches the goal this method displays the score screen and updates the score.
    /// </summary>
    /// <param name="alienCount"></param>
    public void WinGame(int alienCount)
    {
      _playerHUD.ToggleLevelText(false);
      UIManager.Instance.DisplayScoreScreen();
      UIManager.Instance.UpdateScoreText(alienCount, _currentLvlAlienAmount);


    }
    void GameOver()
    {
      StartCoroutine(GameOverSequence());
    }
    /// <summary>
    /// Plays the sequence when the player dies.
    /// </summary>
    /// <returns></returns>
    IEnumerator GameOverSequence()
    {
      Transform playerTransform = _playerHealth.GetComponent<Transform>();
      SpriteRenderer playerSprite = _playerHealth.GetComponent<SpriteRenderer>();

      playerTransform.Rotate(new Vector3(0, 0, -90));
      playerSprite.color = Color.red;
      yield return new WaitForSeconds(1f);
      SpawnManager.Instance.ActivateGame(false);
      Time.timeScale = 0;
      SoundManager.Instance.PlaySound(SoundManager.Sound.PLAYERDEATH);
      UIManager.Instance.DisplayGameOver();
    }
    /// <summary>
    /// Loads a scene Async. waiting for operation to complete before loading.
    /// </summary>
    /// <param name="levelName">Name of the Level</param>
    public void LoadLevelAsync(string levelName)
    {
      //loads the scene
      AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
      Debug.Log($"Loading {levelName}....");

      //pause before going to scene to load needed managers
      operation.allowSceneActivation = false;

      StartCoroutine(WaitForLoading(operation));

    }
    /// <summary>
    /// Waits for async operation to complete allowing scene activation.
    /// </summary>
    /// <param name="operation">Async loading operation</param>
    /// <returns></returns>
    IEnumerator WaitForLoading(AsyncOperation operation)
    {
      while (operation.progress < 0.9f)
      {
        yield return null;
      }

      Debug.Log("Loading Complete");

      operation.allowSceneActivation = true;
      if (Time.timeScale == 0)
      {
        Time.timeScale = 1;
      }

    }
    /// <summary>
    /// Allows scene to be loading on top of level to host any
    /// managers or utilities.
    /// </summary>
    public void LoadLevelAdditive(string sceneName)
    {
      SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    /// <summary>
    /// Unload a scene (async)
    /// </summary>
    public void UnloadLevel(string sceneName)
    {
      AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(sceneName);
      WaitForUnloading(unloadOperation);
    }
    IEnumerator WaitForUnloading(AsyncOperation operation)
    {
      yield return new WaitUntil(() => operation.isDone);
      Resources.UnloadUnusedAssets();
    }


    /// <summary>
    /// Path for saving gameobject data.
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public string PathForSaving(string filename)
    {
      string identifier = SystemInfo.deviceModel;
      Debug.Log($"Device ID: {identifier}");
      string folderToStoreFiles = Application.persistentDataPath;
      string path = System.IO.Path.Combine(folderToStoreFiles, filename);
      if (String.IsNullOrEmpty(path))
      {
        Debug.LogError("No access to save data");
        return null;
      }
      Debug.Log($"Saved file to {path}");
      return path;

    }
    public string GetSceneName()
    {

      string sceneName = SceneManager.GetActiveScene().name;
      if (sceneName.Contains("Level"))
      {
        string level = sceneName.Substring(0, 5);
        char[] removeChars = level.ToCharArray();
        return level + " " + sceneName.Trim(removeChars);

      }
      else
      {
        return null;
      }
    }

  }

}