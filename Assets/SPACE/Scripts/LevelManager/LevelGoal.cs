using System.Collections;
using System.Collections.Generic;
using SPACE.Events;
using SPACE.Sounds;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.LevelManager
{
  public class LevelGoal : MonoBehaviour
  {
    [SerializeField] FloatReference levelMaxAlienCount;
    [SerializeField] FloatReference rescuedAliens;
    [SerializeField] FloatReference currentAliensLeft;
    [SerializeField] GameEventSO winEvent;
    [SerializeField] FloatVariable score;
    [SerializeField] AudioData audioData;
    [SerializeField] AudioSource source;
    [SerializeField] FloatReference volume;

    private void OnEnable()
    {
      source.volume = volume.Value;

    }
    private void Start()
    {
      source.volume = volume.Value;

    }
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

      if (other.CompareTag("Alien"))
      {
        if (rescuedAliens.Value > 0)
        {
          Debug.Log("Alien entered goal");
          score.Value += 10;
          audioData.PlayShot(3, source);
          rescuedAliens.Value--;
          Destroy(other.gameObject);
        }

      }
      else if (other.CompareTag("Player"))
      {
        if (rescuedAliens.Value == 0 && currentAliensLeft.Value == 0)
        {
          winEvent.Raise();
          Destroy(other.gameObject);
        }
      }


    }

  }
}
