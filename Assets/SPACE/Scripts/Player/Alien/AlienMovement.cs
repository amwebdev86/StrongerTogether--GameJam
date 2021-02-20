using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Controller;
namespace SPACE.Players.Aliens
{
    public class AlienMovement : MonoBehaviour
    {
        [SerializeField]MainController controller;
        float alienHorizontalMovement;
        public float AlienSpeed = 3f;
        [HideInInspector]public bool isJoined = false;
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
