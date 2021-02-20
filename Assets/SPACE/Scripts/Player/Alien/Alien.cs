using System.Collections;
using System.Collections.Generic;
using SPACE.Players.Aliens;
using UnityEngine;

namespace SPACE.Players.Aliens
{
  public class Alien : MonoBehaviour
  {
    AlienMovement movement;
    AlienHealth health;
    Transform alienTrans;
    Player player;

    private void Start()
    {
      movement = GetComponent<AlienMovement>();
      health = GetComponent<AlienHealth>();
      alienTrans = GetComponent<Transform>();
      player = FindObjectOfType<Player>();

    }
    /// <summary>
    /// Checks if alien has fallen and if so starts the death coroutine
    /// </summary>
    private void Update()
    {
      if (alienTrans.position.y <= -9)
      {
        alienTrans.Rotate(new Vector3(0, 0, -90));
        player.RemoveFromPlayer(this);
        StartCoroutine(health.AlienDeathRoutine());
      }
    }
    /// <summary>
    /// Checks for enemy contact and takes damage. Or player contact and adds to alien list.
    /// </summary>
    /// <param name="other">GameObject Alien collided with.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag == "Enemy")
      {
        health.DamageAlien();
      }

      if (other.gameObject.name == "Player")
      {
        Player player = other.gameObject.GetComponent<Player>();
        if (movement.isJoined == false)
        {
          movement.isJoined = true;
          player.AddAlien(this);

        }
        else
        {
          return;

        }
        //TODO Fix issue where same alien can be added multiple times.


      }
    }



  }

}