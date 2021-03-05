using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SPACE.Aliens
{
  public class Alien : MonoBehaviour
  {
    AlienMovement movement;
    [SerializeField] AlienData alienData;
    private bool isJoinded;
  
    private void Start()
    {
      movement = GetComponent<AlienMovement>();

    }
    private void Update()
    {
      movement.isJoined = isJoinded;
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
    public AlienData GetAlienData()
    {
      return alienData;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player") && !isJoinded)
      {
        isJoinded = true;
      }
    }

  }

}