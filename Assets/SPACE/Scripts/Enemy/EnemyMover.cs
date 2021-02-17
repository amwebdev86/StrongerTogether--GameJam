﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Controller;
using SPACE.Managers;
namespace SPACE.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        MainController controller;
        public float enemySpeed = 15f;
        float rndRng;
        void Start()
        {
            controller = GetComponent<MainController>();
            StartCoroutine(EnemyMovement());
        }
        private void Update()
        {
            //rndRng = Random.Range(-1, 2);
            Debug.Log(rndRng);
        }
        void FixedUpdate()
        {
            
            controller.Move(rndRng * enemySpeed * Time.fixedDeltaTime, false, false);
        }
        IEnumerator EnemyMovement()
        {
            while (GameManager.Instance.gameRunning)
            {
                rndRng = Random.Range(-1, 2);
                yield return new WaitForSeconds(3);
                //rndRng = Random.Range(-1, 2);
                //yield return new WaitForSeconds(3);
                //rndRng = Random.Range(-1, 2);
            }
        

        }
    }
}
