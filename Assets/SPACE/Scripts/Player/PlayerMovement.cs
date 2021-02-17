using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Controller;
namespace SPACE.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]MainController controller;
        float horizontalInput = 0;
        public float RunSpeed = 12;
        bool jump = false;
        bool isCrouching = false;
        public KeyCode jumpKey = KeyCode.Space, crouchKey = KeyCode.C;
        [SerializeField] Animator playerAnim;
     

        private void Update()
        {

            PlayerInput();
        }

        private void PlayerInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal") * RunSpeed;
            playerAnim.SetFloat("horizontal", horizontalInput / RunSpeed);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;

              
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Crouching");
                isCrouching = true;
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                isCrouching = false;
            }
        }

        private void FixedUpdate()
        {

            //moves character in Fixedupdate.. runs a fixed amount of time per second
            controller.Move(horizontalInput * Time.fixedDeltaTime, isCrouching, jump);
            jump = false;
            

        }
    }
}
