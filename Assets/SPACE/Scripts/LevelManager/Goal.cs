using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Players;
using SPACE.Managers;

namespace SPACE.LevelManager
{

  public class Goal : MonoBehaviour
  {
    [SerializeField] int _GoalAmount = 1;//required min amount to beat the level.



    /// <summary>
    /// /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //   Debug.Log("Entering goal");
    //   if (other.gameObject.tag == "Player")
    //   {
    //     Debug.Log("Player entered goal");
    //     var player = other.gameObject.GetComponent<Player>();
    //     int playerCount = player.AlientListCount();
    //     if (playerCount >= _GoalAmount)
    //     {
    //       GameManager.Instance.WinGame(playerCount);
    //       Debug.Log("YOU WON!");

    //     }
    //     else
    //     {
    //       //TODO: Notify player not enough Aliens
    //       return;
    //     }
    //   }
    // }

    //TODO: Create corotine to add ship animation and winning sounds

  }

}