using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Utils;
namespace SPACE.Managers
{

  /// <summary>
  /// Allows to create sounds with a sound type
  /// </summary>

  public class SoundManager : Singleton<SoundManager>
  {
    [System.Serializable]
    public class SoundAudioClip
    {
      public Sound sound;
      public AudioClip audioClip;
    }
    public enum Sound
    {
      PLAYERJUMP, PLAYERDEATH, PLAYERINTERACT, ACHEIVEMENT, HIT, PICKUP, FALL
    }
    public SoundAudioClip[] soundAudioClipArray;

    /// <summary>
    /// Takes a Sound type and plays the associated audioclip in a one shot.
    /// </summary>
    /// <param name="sound">Sound enum</param>
    public void PlaySound(Sound sound)
    {
      GameObject soundObj = new GameObject("Sound");
      AudioSource audioSource = soundObj.AddComponent<AudioSource>();
      audioSource.PlayOneShot(GetAudioClip(sound));
    }
    /// <summary>
    /// Gets the audio clip based on the Sound enum
    /// </summary>
    /// <param name="sound">enum Sound type</param>
    /// <returns>an audioclip</returns>
    private AudioClip GetAudioClip(Sound sound)
    {
      foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
      {
        if (soundAudioClip.sound == sound)
        {
          return soundAudioClip.audioClip;
        }
      }
      Debug.LogError("Sound Manager: " + sound + " Not found!");
      return null;
    }
  }

}