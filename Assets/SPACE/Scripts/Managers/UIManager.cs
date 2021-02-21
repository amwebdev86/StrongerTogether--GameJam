using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using SPACE.Utils;
using SPACE.UI;

namespace SPACE.Managers
{
  public class UIManager : Singleton<UIManager>
  {
    [SerializeField] HealthBar healthBarDisplay;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Text scoretext;
    // Start is called before the first frame update
    bool isPaused = false;

    void Start()
    {
      gameOverPanel.SetActive(false);
      if (!healthBarDisplay)
        healthBarDisplay = GetComponentInChildren<HealthBar>();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
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
      pausePanel.SetActive(isPaused);
      if (isPaused)
      {
        Time.timeScale = 0;
      }
      else
      {
        Time.timeScale = 1;
      }
    }

    public void SetInitialHealth(int amount)
    {
      healthBarDisplay.SetMaxHealth(amount);

    }
    public void UpdatePlayerHealth(int health)
    {
      healthBarDisplay.SetHealth(health);
    }
    public void DisplayGameOver()
    {
      gameOverPanel.SetActive(true);
    }
    public void DisplayScoreScreen()
    {
      scorePanel.SetActive(true);
    }
    /// <summary>
    /// Restarts the current Level.
    /// </summary>
    public void RestartLevel()
    {
      //GameManager.Instance.UnloadLevel(SceneManager.GetActiveScene().name);
      GameManager.Instance.LoadLevelAsync(SceneManager.GetActiveScene().name);


    }
    public void LoadNextLevel()
    {
      //TODO load next level.
      GameManager.Instance.LoadLevelAsync("Credits");
    }

    /// <summary>
    /// Updates the score screen text. Called on game won completion.
    /// </summary>
    /// <param name="playerAlienCount"></param>
    /// <param name="levelMaxCount"></param>
    public void UpdateScoreText(int playerAlienCount, int levelMaxCount)
    {
      Debug.Log(playerAlienCount);
      float completion = (float)playerAlienCount / (float)levelMaxCount;
      Debug.Log($"Completion is {completion}");
      float percentComplete = Mathf.Round(completion * 100);
      string scoreTxt = $"SCORE: {playerAlienCount}/{levelMaxCount} --- {percentComplete}%";
      //string scoreTxt = "What the fuck...";

      scoretext.text = scoreTxt;

    }
    public void QuitToMenu()
    {
      GameManager.Instance.LoadLevelAsync("MainMenu");
    }

  }
}