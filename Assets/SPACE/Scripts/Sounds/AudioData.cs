using System.Collections;
using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.Sounds
{
  [CreateAssetMenu(menuName = "GalacticBond/Audio/AudioData", fileName = "AudioData")]
  public class AudioData : AudioEvent
  {

    public FloatVariable volume;
    public AudioClip[] fxClips;
    public AudioClip musicClip;
    public void PlayShot(int index, AudioSource source)
    {
      source.clip = fxClips[index];
      source.PlayOneShot(source.clip);
    }
    public void PlayClip(int index, AudioSource source)
    {
      source.clip = fxClips[index];
      Play(source);
    }
    public override void Play(AudioSource source)
    {
      if (musicClip == null) return;

      source.loop = true;
      source.clip = musicClip;
      source.volume = volume.Value;
      source.Play();
    }
  
    public void AdjustVolume(float value)
    {
      if (value > 1)
      {
        value = 1;
      }
      if (value <= 0)
      {
        value = 0;
      }
      volume.Value = value;
    }
    public void AudioVolUpdate(float value, AudioSource source)
    {
      volume.Value = value;
      if (source.volume != volume.Value)
      {
        source.volume = volume.Value;
      }

    }
    public void PauseMusic(AudioSource source)
    {
      source.Pause();
    }
    public void ResumeMusic(AudioSource source)
    {
      source.Play();
    }
    public void StopPlaying(AudioSource source)
    {
      source.Stop();
    }
  }
}
