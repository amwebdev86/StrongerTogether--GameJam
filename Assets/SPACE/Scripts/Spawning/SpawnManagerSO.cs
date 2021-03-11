using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SPACE.Spawning
{
  [CreateAssetMenu(fileName = "SpawnManager", menuName = "GalacticBond/Spawning/SpawnManagerScriptableObject", order = 1)]
  public class SpawnManagerSO : ScriptableObject
  {
    public string PrefabName;
    public int NumberOfPrefabsToCreate;
    public Vector3[] SpawnPoints;
  }

}