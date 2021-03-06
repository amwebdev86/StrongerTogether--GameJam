﻿//using SPACE.UI;
using SPACE.Managers;
using UnityEngine;

namespace SPACE.Players
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

    private void Start()
    {
      _currentHealth = _maxHealth;
      //_healthBar.SetMaxHealth(_maxHealth);
    }


    /// <summary>
    /// Damages the player.
    /// </summary>
    /// <param name="damage">Amount to damage player</param>
    public void TakeDamage(int damage)
    {

      _currentHealth -= damage;

      GameManager.Instance.UpdateHealthBar(_currentHealth);
      if (_currentHealth <= 0)
      {
        _currentHealth = 0;
        
        GameManager.Instance.m_GameOverEvent.Invoke();

      }

    }
    /// <summary>
    /// Heals the Player
    /// </summary>
    /// <param name="amount">Amount to heal the player</param>
    public void Heal(int amount)
    {
      _currentHealth += amount;
      if (_currentHealth > _maxHealth)
      {
        _currentHealth = _maxHealth;
      }
    }

  }

}