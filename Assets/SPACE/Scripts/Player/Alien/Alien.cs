using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Player.Alien
{
    public class Alien : MonoBehaviour
    {
        AlienMovement movement;

        private void Start()
        {
            movement = GetComponent<AlienMovement>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == "Player")
            {
                movement.isJoined = true;
            }
        }
    }

}