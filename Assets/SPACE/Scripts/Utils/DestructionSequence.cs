using System.Collections;
using UnityEngine;

namespace AMGame.Core.Utilities
{


  public abstract class DestructionSequence : ScriptableObject
  {
    
    public abstract IEnumerator SequenceCoroutine(MonoBehaviour runner);
  }
}