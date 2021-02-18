
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

                //TODO: Call death animation.
                Destroy(gameObject);
            }

        }
        /// <summary>
        /// Sent when another object enters a trigger collider attached to this
        /// object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                DamageEnemy(1);

            }

        }


    }

}