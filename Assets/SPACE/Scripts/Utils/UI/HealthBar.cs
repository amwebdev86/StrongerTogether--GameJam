//using PlayerCharacter.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SPACE.UI
{
  /// <summary>
  /// Sets the slider value of the health bar and sets current value.
  /// </summary>
  public class HealthBar : MonoBehaviour
  {
    [SerializeField]
    Slider slider;
    [SerializeField]
    Gradient gradient;
    [SerializeField]
    Image fill;


    /// <summary>
    /// Sets the Healthbar maxValue and currentValue to provided value
    /// </summary>
    /// <param name="maxHealth">The maxium player health</param>
    public void SetMaxHealth(int maxHealth)
    {

      slider.maxValue = maxHealth;
      slider.value = maxHealth;
      fill.color = gradient.Evaluate(1f);
    }
    /// <summary>
    /// Set the current value of the Healthbar. Useful for updating the healthbar on HP changes.
    /// </summary>
    /// <param name="health">the current player health</param>
    public void SetHealth(int health)
    {

      slider.value = health;
      fill.color = gradient.Evaluate(slider.normalizedValue);
      //Debug.Log($"the current health value recieved was {health}");
    }


  }

}