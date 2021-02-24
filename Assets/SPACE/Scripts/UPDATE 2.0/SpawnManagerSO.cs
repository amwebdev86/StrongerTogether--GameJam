using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AMGame.Core.SpawnSystem
{
  [CreateAssetMenu(fileName = "SpawnManager", menuName = "AMGame/SpawnSystem/SpawnManagerScriptableObject", order = 1)]
  public class SpawnManagerSO : ScriptableObject
  {
    public string PrefabName;
    public int NumberOfPrefabsToCreate;
    public Vector3[] SpawnPoints;
  }

}