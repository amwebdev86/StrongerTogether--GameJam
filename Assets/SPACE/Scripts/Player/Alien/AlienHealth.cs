using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Players.Aliens
{
  public class AlienHealth : MonoBehaviour
  {
    [SerializeField] int _Health = 3;
    Alien alien;
    Player player;

    private void Start()
    {
      alien = GetComponent<Alien>();
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
      player.RemoveFromPlayer(alien);
      alienRender.color = Color.red;
      Destroy(gameObject);



    }
  }

}