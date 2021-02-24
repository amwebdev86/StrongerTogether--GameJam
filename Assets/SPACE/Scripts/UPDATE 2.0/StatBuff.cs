using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMGame.Core.StatSystem.Buffs
{
  public abstract class StatBuff : ScriptableObject
  {
    public abstract void Apply(GameObject target);

  }

}