using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AMGame.Core.StatSystem
{
  [CreateAssetMenu(fileName = "FloatStat", menuName = "AMGame/Stats/Stat(Float)", order = 2)]

  public class FloatVariable : ScriptableObject
  {
    public float Value;
  }

}

