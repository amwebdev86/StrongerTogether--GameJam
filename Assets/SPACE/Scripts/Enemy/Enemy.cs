using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Managers;

namespace SPACE.Enemy
{
    public class Enemy : MonoBehaviour
    {
        EnemyHealth health;
        [SerializeField] int enemyDamage = 10;
        private void Start()
        {
            health = GetComponent<EnemyHealth>();
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                health.DamageEnemy(1);

            }

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.Instance.DamagePlayer(enemyDamage);
            }
        }


    }

}