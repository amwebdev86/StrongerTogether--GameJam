using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AMGame.Core.Utilities;

namespace AMGame.Core.Sound
{
  public class SimpleAudioEvent : AudioEvent
  {
    public AudioClip[] clips;
    [Range(0, 20)]
    public float volume;

    public override void Play(AudioSource source)
    {
      if(clips.Length == 0) return;
      source.clip = clips[Random.Range(0, clips.Length)];
      source.volume = 10;
      source.pitch = 2;
      source.Play();

    }
  }

}