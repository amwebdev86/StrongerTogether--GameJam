using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SPACE.Aliens
{
  public class Alien : MonoBehaviour
  {
    AlienMovement movement;
    [SerializeField] AlienData alienData;
    //AlienHealth health;
    // Transform alienTrans;
    //Player player;

    // private void onEnable()
    // {
    //   // health = GetComponent<AlienHealth>();

    //   //alienTrans = GetComponent<Transform>();
    //   //player = FindObjectOfType<Player>();


    // }
    private void Start()
    {
      movement = GetComponent<AlienMovement>();

    }
    private void Update()
    {
      movement.isJoined = alienData.isJoinded;
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
    /// <summary>
    /// Checks for enemy contact and takes damage. Or player contact and adds to alien list.
    /// </summary>
    /// <param name="other">GameObject Alien collided with.</param>
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //   if (other.gameObject.tag == "Enemy")
    //   {
    //     health.DamageAlien();
    //   }

    //   if (other.gameObject.name == "Player")
    //   {
    //     Player player = other.gameObject.GetComponent<Player>();
    //     if (movement.isJoined == false)
    //     {
    //       movement.isJoined = true;
    //       player.AddAlien(this);

    //     }
    //     else
    //     {
    //       return;

    //     }
    //     //TODO Fix issue where same alien can be added multiple times.


    //   }
    // }



  }

}