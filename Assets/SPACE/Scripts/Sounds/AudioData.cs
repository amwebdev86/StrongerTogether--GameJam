using System.Collections;
using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.Sounds
{
  [CreateAssetMenu(menuName = "GalacticBond/Audio/AudioData", fileName = "AudioData")]
  public class AudioData : AudioEvent
  {

    public FloatVariable volume;//TODO Options has the var that changes this value.
    public AudioClip[] fxClips;
    public AudioClip musicClip;
    public void PlayClip(int index, AudioSource source)
    {
      source.clip = fxClips[index];
      Play(source);
    }
    public override void Play(AudioSource source)
    {
      if (fxClips.Length == 0) return;
      //source.clip = fxClips[0];
      source.volume = volume.Value;
      source.Play();
    }
    public void PlayMusic(AudioSource source)
    {
      if (musicClip == null) return;

      source.loop = true;
      source.clip = musicClip;
      source.volume = volume.Value;
      source.Play();
    }
    public void AdjustVolume(float value){
        if(value > 1 ){
        value = 1;
      }
      if(value <= 0 ){
        value = 0;
      }
      volume.Value = value;
    }
  }
}
