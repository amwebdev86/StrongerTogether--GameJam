
using UnityEngine;


namespace SPACE.Enemy
{
  public class Enemy : MonoBehaviour
  {

    private Rigidbody2D enemyRb;
    [SerializeField] private float enemySpeed;

    private void Start()
    {

      enemyRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

      EnemyMovement();
    }
    private void Update()
    {
      FlipEnemySprite();
    }

    private void FlipEnemySprite()
    {
      if (enemyRb.velocity.x > 0)
      {
        GetComponent<SpriteRenderer>().flipX = true;
      }
      else if (enemyRb.velocity.x < 0)
      {
        GetComponent<SpriteRenderer>().flipX = false;
      }
    }

    private void EnemyMovement()
    {
      enemyRb.velocity = new Vector2(GameObject.Find("Player").transform.position.x * enemySpeed * Time.fixedDeltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player"))
      {
        Destroy(gameObject);
      }
    }

  }

}