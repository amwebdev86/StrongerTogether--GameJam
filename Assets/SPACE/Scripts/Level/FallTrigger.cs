using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Players;

namespace SPACE.LevelManager
{
  public class FallTrigger : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "Player")
      {
        Player player = other.gameObject.GetComponent<Player>();
        player.PlayerFallSequence();
      }
    }
  }

}