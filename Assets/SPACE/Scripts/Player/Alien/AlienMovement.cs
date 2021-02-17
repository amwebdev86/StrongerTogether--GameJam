﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SPACE.Player.Alien
{
    public class AlienMovement : MonoBehaviour
    {
        [SerializeField]MainController controller;
        float alienHorizontalMovement;
        public float AlienSpeed = 3f;
        [SerializeField] bool isJoined = false;
        bool alienJump = false;
        private void Update()
        {
            if (isJoined)
            {
                alienHorizontalMovement = Input.GetAxisRaw("Horizontal") * AlienSpeed;
                if (Input.GetKeyDown(KeyCode.Space) && isJoined)//have player change bool vs same key button.
                {
                    alienJump = true;
                }
            }

           
        }
        private void FixedUpdate()
        {
            if (isJoined)
            {
                controller.Move(alienHorizontalMovement * Time.fixedDeltaTime, false, alienJump);
                alienJump = false;

            }
               
        }
       
    }
}
