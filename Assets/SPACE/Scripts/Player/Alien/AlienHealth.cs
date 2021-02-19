using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Player.Alien
{
  public class AlienHealth : MonoBehaviour
  {
    [SerializeField] int _Health;
    Transform alienTrans;

    private void Start()
    {
      if (_Health == 0) { _Health = 3; }
      alienTrans = GetComponent<Transform>();

    }

    private void Update()
    {
      if (alienTrans.position.y <= -9)
      {
        StartCoroutine(AlienDeathRoutine());
      }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag == "Enemy")
      {
        DamageAlien();
      }
    }
    /// <summary>
    /// Damages Alien by 1 HP
    /// </summary>
    void DamageAlien()
    {
      _Health -= 1;
      if (_Health <= 0)
      {
        StartCoroutine(AlienDeathRoutine());
      }
    }
    IEnumerator AlienDeathRoutine()
    {

      SpriteRenderer alienRender = GetComponent<SpriteRenderer>();
      Color originalColor = alienRender.color;
      alienTrans.Rotate(new Vector3(0, 0, -90));
      yield return new WaitForSeconds(.5f);
      alienRender.color = Color.red;
      yield return new WaitForSeconds(.5f);
      alienRender.color = originalColor;
      yield return new WaitForSeconds(1f);
      alienRender.color = Color.red;
      //TODO: Call Companion Script to decrease current Alien Count.
      Destroy(gameObject);



    }
  }

}