using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Controller;
namespace SPACE.Aliens
{
  public class AlienMovement : MonoBehaviour
  {
    [SerializeField] MainController controller;

    float alienHorizontalMovement;
    public float AlienSpeed = 3f;
    [HideInInspector] public bool isJoined = false;
    bool alienJump = false;
    public KeyCode alienJumpKey = KeyCode.W;

    private void Update()
    {
      if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
      {
        AlienSpeed = 0;
      }
      else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
      {
        AlienSpeed = 60;
      }
      if (isJoined)
      {

        alienHorizontalMovement = Input.GetAxisRaw("Horizontal") * AlienSpeed;
        if (Input.GetAxis("Vertical") >= 1)
        {
          alienJump = true;
        }


      }
      // if (Input.GetKeyDown(stopAlienKey) && isJoined)
      // {
      //   if (!isStopped)
      //   {
      //     Debug.Log(isStopped);
      //     isStopped = true;
      //   }
      //   else if (isStopped)
      //   {
      //     Debug.Log(isStopped);
      //     isStopped = false;
      //   }
      // }
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
