using SPACE.UI;
using UnityEngine;

namespace SPACE.Player
{
    /// <summary>
    /// Controls the player's health.
    /// </summary>
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        int _maxHealth;
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
        }
        int _currentHealth;
        public int CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
        }
        [SerializeField]
        HealthBar _healthBar;
        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthBar.SetMaxHealth(_maxHealth);
        }
       /// <summary>
       /// Damages the player.
       /// </summary>
       /// <param name="damage">Amount to damage player</param>
        public void TakeDamage(int damage)
        {
            if(_currentHealth == 0)
            {
                Debug.LogWarning("Yo Player been dead homie!");
                return;
            }
            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);
            if(_currentHealth < 0)
            {
                //TODO: Invoke Gameover event
                _currentHealth = 0;
                Debug.Log($"Player died health = {_currentHealth}... Should be game over here");
            }
            Debug.Log($"Player was damaged {_currentHealth}-{damage}");
        }
        /// <summary>
        /// Heals the Player
        /// </summary>
        /// <param name="amount">Amount to heal the player</param>
        public void Heal(int amount)
        {
            _currentHealth += amount;
            if(_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
        
    }

}