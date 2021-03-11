using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Spawning
{
  public class Spawner : MonoBehaviour
  {
    public GameObject EntityToSpawn;
    public SpawnManagerSO SpawnManager;
    int instanceNumber = 1;
    private void Start()
    {
      SpawnEntities();
    }
    void SpawnEntities()
    {
      int currentSpawnPointIndex = 0;
      for (int i = 0; i < SpawnManager.NumberOfPrefabsToCreate; i++)
      {
        GameObject currentEntity = Instantiate(EntityToSpawn, SpawnManager.SpawnPoints[currentSpawnPointIndex], Quaternion.identity);
        currentEntity.name = SpawnManager.PrefabName + instanceNumber;
        currentSpawnPointIndex = (currentSpawnPointIndex + 1) % SpawnManager.SpawnPoints.Length;
        instanceNumber++;
      }
    }

  }

}