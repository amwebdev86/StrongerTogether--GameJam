using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Managers;
namespace SPACE.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        Vector2 speed = new Vector2(50, 50);
        //Vector2 movement 
        [SerializeField]
        Rigidbody2D _Rb2d;
        Animator playerAnim;
        public bool isTopDown = false;
        // bool isGrounded = true;
        private void Start()
        {
            playerAnim = GetComponentInChildren<Animator>();
            if (!playerAnim)
            {
                Debug.LogError("No animator found on player!");
            }
        }
        private void FixedUpdate()
        {
            if (isTopDown)
            {

                TopDownControls();
            }
            else
            {
                SideScrollingControls();

            }
        }

        private void TopDownControls()
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
            if(inputX < 0)
            {
                playerAnim.SetBool("walkR", false);

                playerAnim.SetBool("walkL", true);
            }
            else if(inputX > 0)
            {

                playerAnim.SetBool("walkL", false);
                playerAnim.SetBool("walkR", true);

            }
            else
            {
                playerAnim.SetBool("walkL", false);
                playerAnim.SetBool("walkR", false);
            }
            if(inputY < 0)
            {
                playerAnim.SetBool("walkDown", true);
                playerAnim.SetBool("walkUp", false);
            }else if(inputY > 0)
            {
                playerAnim.SetBool("walkDown", false);
                playerAnim.SetBool("walkUp", true);
            }
            else
            {
                playerAnim.SetBool("walkDown", false);
                playerAnim.SetBool("walkUp", false);
            }
            
            _Rb2d.velocity = movement;
        }
        private void SideScrollingControls()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(speed.x * horizontalMovement, 0);
            _Rb2d.velocity = movement;
        }
    }
}
