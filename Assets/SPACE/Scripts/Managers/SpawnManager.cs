using System.Collections;
using SPACE.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Managers
{
    public class SpawnManager : Singleton<SpawnManager>
    {
        bool gameActive = false;
        [SerializeField]
        GameObject[] enemyPrefabs;
        [SerializeField]
        GameObject Player;
        [SerializeField] // allows access to variable in Unity editor without making it public.
        GameObject[] spawnLocations;
        public int SpawnTimer = 5;
        public bool CR_Running = false;
       
        /// <summary>
        /// Spawns Enemys at set interval using coroutine.
        /// </summary>
        /// <returns>yields for amount of seconds then instantiates another GO</returns>
        public IEnumerator Spawner()
        {
            CR_Running = true;
            while (gameActive)
            {
                yield return new WaitForSeconds(SpawnTimer);
                //TODO: Instantiate Enemy at spawner postion.
                //Instantiate(enemyPrefabs[gameUtils.RandomNum(0, enemyPrefabs.Length)], spawnLocations[gameUtils.RandomNum(0,spawnLocations.Length)], Quaternion.identity);
               // Debug.Log(GameUtility.RandomNum(0, 10));
            }
            CR_Running = false;
        }
        
        public void ActivateGame(bool activate)
        {
            gameActive = activate;
        }
       
    }
}
