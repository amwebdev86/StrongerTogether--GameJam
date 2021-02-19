
using System.Collections;
using UnityEngine;
namespace SPACE.Enemy
{

  public class EnemyHealth : MonoBehaviour
  {
    [SerializeField] float health = 1;

    public void DamageEnemy(float amount)
    {
      health -= amount;
      if (health < 0)
      {
        health = 0;
        StartCoroutine(EnemyDeath());

      }

    }

    IEnumerator EnemyDeath()
    {
      Transform enemyTransform = GetComponent<Transform>();
      enemyTransform.Rotate(new Vector3(0, 0, -90));
      yield return new WaitForSeconds(1f);
      Destroy(gameObject);



    }




  }

}