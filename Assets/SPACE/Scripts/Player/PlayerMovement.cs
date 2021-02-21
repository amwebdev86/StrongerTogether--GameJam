
using UnityEngine;
using SPACE.Controller;
using SPACE.Managers;
namespace SPACE.Players
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] MainController controller;
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
      if (horizontalInput != 0 && controller.CheckPlayerGrounded())
      {
        SoundManager.Instance.PlaySound(SoundManager.Sound.PLAYERMOVE, transform.position);

      }
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
