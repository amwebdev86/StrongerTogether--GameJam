using System.Collections;
using System.Collections.Generic;
using SPACE.Controller;
using UnityEngine;

namespace SPACE.Aliens
{
  public class Alien : MonoBehaviour
  {
    AlienMovement movement;
    [SerializeField] AlienData alienData;
    MainController controller;
    private bool isJoinded;
    float alienHorizontalMovement;
    public float alienSpeed = 60f;
    bool alienJump = false;


    private void Start()
    {
      movement = GetComponent<AlienMovement>();
      controller = GetComponent<MainController>();

    }
    // private void Update()
    // {
    //   movement.isJoined = isJoinded;
    // }
    private void FixedUpdate()
    {
      if (isJoinded)
      {
        alienHorizontalMovement = Input.GetAxisRaw("Horizontal") * alienSpeed;

        controller.Move(alienHorizontalMovement * Time.fixedDeltaTime, false, alienJump);
      }
    }

    public void AlienFallSequence()
    {
      gameObject.transform.Rotate(new Vector3(0, 0, -90));
      // player.RemoveFromPlayer(this);
      StartCoroutine(AlienDeathRoutine());
    }
    public IEnumerator AlienDeathRoutine()
    {

      SpriteRenderer alienRender = GetComponent<SpriteRenderer>();
      Color originalColor = alienRender.color;
      yield return new WaitForSeconds(.5f);
      alienRender.color = Color.red;
      yield return new WaitForSeconds(.5f);
      alienRender.color = originalColor;
      yield return new WaitForSeconds(1f);
      //player.RemoveFromPlayer(alien);
      alienRender.color = Color.red;
      yield return new WaitForSeconds(1);
      Destroy(gameObject);
      yield return null;

    }
    private void AlienJump()
    {
      if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && controller.GetIsGrounded())
      {
        alienJump = true;
      }
      else if (controller.GetIsGrounded())
      {
        alienJump = false;
      }
    }
    private void ToggleAlienMovement()
    {
      if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
      {
        alienSpeed = 0;
      }
      else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
      {
        alienSpeed = 60;
      }
    }
    // public AlienData GetAlienData()
    // {
    //   return alienData;
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player") && !isJoinded)
      {
        isJoinded = true;
      }
    }

  }

}