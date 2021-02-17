using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Managers;
namespace SPACE.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]MainController controller;
        float horizontalInput = 0;
        public float RunSpeed = 12;
        bool jump = false;
        private void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal") * RunSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                Debug.Log(jump);
            }
        }
        private void FixedUpdate()
        {
            //moves character in Fixedupdate.. runs a fixed amount of time per second
            controller.Move(horizontalInput * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
}
