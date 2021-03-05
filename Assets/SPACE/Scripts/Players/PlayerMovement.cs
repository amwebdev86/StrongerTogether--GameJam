using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Controller;
using SPACE.Utils;

namespace SPACE.Players
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] MainController controller;
    float horizontalInput = 0;
    public float RunSpeed = 12;
    bool jump = false;
    [SerializeField] bool isCrouching = false;
    public KeyCode jumpKey = KeyCode.Space;
    [SerializeField] Animator playerAnim;
    [SerializeField] FloatVariable playerCrouchSpeed;
    private void Start()
    {
      if (playerCrouchSpeed.Value != 1)
      {
        playerCrouchSpeed.Value = 1;
      }
    }
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
      if (Input.GetAxis("Vertical") < 0)
      {
        Debug.Log("Crouching");
        isCrouching = true;
        playerCrouchSpeed.Value = 0;

      }
      else if (Input.GetAxis("Vertical") == 0)
      {
        isCrouching = false;
        Debug.Log("Not Crouching");
        playerCrouchSpeed.Value = 1f;

      }
    }
    public bool PlayerCrouch(bool crouch)
    {
      isCrouching = crouch;
      return isCrouching;
    }

    private void FixedUpdate()
    {

      //moves character in Fixedupdate.. runs a fixed amount of time per second
      controller.Move(horizontalInput * Time.fixedDeltaTime, isCrouching, jump);
      jump = false;


    }
  }
}
