using System.Collections;
using SPACE.Controller;
using SPACE.Events;
using SPACE.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace SPACE.Aliens
{
  public class Alien : MonoBehaviour
  {

    [SerializeField] AlienData alienData;
    [SerializeField] FloatVariable alienRescueCount;
    public GameEventSO onJoinEvent;
    MainController controller;
    private bool isJoinded;
    float alienHorizontalMovement;
    public float alienSpeed = 60f;
    bool alienJump = false;
    bool isStopped = false;


    private void Start()
    {

      controller = GetComponent<MainController>();

    }
    private void Update()
    {
      AlienJump();
      ToggleAlienMovement();

    }

    private void FixedUpdate()
    {
      if (isJoinded && !isStopped)
      {
        alienHorizontalMovement = Input.GetAxisRaw("Horizontal") * alienSpeed;

        controller.Move(alienHorizontalMovement * Time.fixedDeltaTime, false, alienJump);
      }
    }

    public void AlienFallSequence()
    {
      gameObject.transform.Rotate(new Vector3(0, 0, -90));
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
      else if (!controller.GetIsGrounded())
      {
        alienJump = false;
      }
    }
    private void ToggleAlienMovement()
    {
      if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
      {
        isStopped = true;
      }
      else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
      {
        isStopped = false;
      }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player") && !isJoinded)
      {
        isJoinded = true;
        alienRescueCount.Value++;
        onJoinEvent.Raise();
      }
    }

  }

}