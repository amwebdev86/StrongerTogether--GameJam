using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Player.Aliens
{
  public class AlienHealth : MonoBehaviour
  {
    [SerializeField] int _Health = 3;
    Player player;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }




    /// <summary>
    /// Damages Alien by 1 HP
    /// </summary>
    public void DamageAlien()
    {
      _Health -= 1;
      if (_Health <= 0)
      {
        StartCoroutine(AlienDeathRoutine());
      }
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
      Destroy(gameObject);



    }
  }

}