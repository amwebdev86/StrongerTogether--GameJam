using UnityEngine.SceneManagement;
using UnityEngine;
using SPACE.Utils;
using SPACE.UI;

namespace SPACE.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] HealthBar healthBarDisplay;
        [SerializeField] GameObject gameOverPanel;
        // Start is called before the first frame update
        private void Awake()
        {
            Debug.Log(SceneManager.GetActiveScene().name);
        }
        void Start()
        {
            gameOverPanel.SetActive(false);
            if (!healthBarDisplay)
                healthBarDisplay = GetComponentInChildren<HealthBar>();


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
        /// <summary>
        /// Restarts the current Level.
        /// </summary>
        public void RestartLevel()
        {
            GameManager.Instance.UnloadLevel(SceneManager.GetActiveScene().name);
            GameManager.Instance.LoadLevelAsync(SceneManager.GetActiveScene().name);


        }
        public void QuitToMenu()
        {
            GameManager.Instance.LoadLevelAsync("MainMenu");
        }

    }
}