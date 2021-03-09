
using UnityEngine;


namespace SPACE.Enemy
{
  public class Enemy : MonoBehaviour
  {

    private Rigidbody2D enemyRb;
    [SerializeField] private float enemySpeed;


    [SerializeField] bool isFacingRight;
    // [SerializeField] bool isMovingRight = true;
    int unitsToMove = 15;
    Vector3 velocity;
    float endPos, startPos;
    private void Awake()
    {

      enemyRb = GetComponent<Rigidbody2D>();
      startPos = transform.position.x;
      endPos = startPos + unitsToMove;
      //endPos = GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x;
      isFacingRight = transform.position.x > 0;
    }

    private void FixedUpdate()
    {

    }
    private void Update()
    {
      //FlipEnemySprite();
      EnemyMovement();
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
      // transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
      // isFacingRight = transform.position.x > 0;
    }

    private void EnemyMovement()
    {
      
      float distance = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
      Vector3 targetVelocity = new Vector2(0 * 10f, enemyRb.velocity.y);

      if (transform.position.x >= endPos)
      {
        startPos = transform.position.x;
        endPos = startPos - unitsToMove;
        targetVelocity = new Vector2(1 * 10f, enemyRb.velocity.y);

      }
      else if (transform.position.x <= endPos)
      {
        startPos = transform.position.x;
        //endPos = startPos + unitsToMove;
        targetVelocity = new Vector2(-1 * 10f, enemyRb.velocity.y);

      }
      Debug.Log(startPos + "," + endPos);

      //smooth out movement and apply it to the character
      enemyRb.velocity = Vector3.SmoothDamp(enemyRb.velocity, targetVelocity, ref velocity, .3f);

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