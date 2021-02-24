using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMGame.Core.Utilities{
  public abstract class AudioEvent : ScriptableObject
  {
    public abstract void Play(AudioSource source);
  }
}
