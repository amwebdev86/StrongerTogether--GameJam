
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
    CameraFollow cam;

    private void Start()
    {
      cam = Camera.main.gameObject.GetComponent<CameraFollow>();
    }
    private void LateUpdate()
    {
      if (!controller.CheckPlayerGrounded())
      {
        cam.RectOffset = new Vector3(cam.RectOffset.x, -2f, cam.RectOffset.z);

      }
      if (isCrouching)
      {
        cam.RectOffset = new Vector3(cam.RectOffset.x, -4f, cam.RectOffset.z);

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
