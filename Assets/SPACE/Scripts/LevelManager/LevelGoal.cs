using System.Collections;
using System.Collections.Generic;
using SPACE.Sounds;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.LevelManager
{
  public class LevelGoal : MonoBehaviour
  {
    [SerializeField] FloatReference goalMaxAmount;
    [SerializeField] FloatReference rescuedAliens;
    [SerializeField] FloatReference playerHealth;
    [SerializeField] FloatVariable score;
    [SerializeField] AudioData audioData;
    [SerializeField] AudioSource source;


    private void OnTriggerEnter2D(Collider2D other)
    {

      if (other.gameObject.tag == "Alien")
      {
        Debug.Log("Alien entered goal");
        score.Value += 10;
        audioData.PlayFX(3, source);
        Destroy(other.gameObject);
      }

    }

  }
}
