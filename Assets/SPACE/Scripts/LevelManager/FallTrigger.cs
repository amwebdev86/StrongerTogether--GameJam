using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Players;
using SPACE.Aliens;


namespace SPACE.LevelManager
{
  public class FallTrigger : MonoBehaviour
  {
    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        Player player = other.gameObject.GetComponent<Player>();
        player.PlayerFallSequence();
      }
      // else if (other.CompareTag("Alien"))
      // {
      //   Alien alien = other.gameObject.GetComponent<Alien>();
      //   alien.AlienFallSequence();

      // }
    }
  }

}