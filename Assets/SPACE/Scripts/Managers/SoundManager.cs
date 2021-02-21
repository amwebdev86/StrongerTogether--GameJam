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
      PLAYERJUMP, PLAYERDEATH, PLAYERINTERACT, ACHEIVEMENT, HIT, FALL,
      MENUCLICK, PLAYERMOVE, GAMEOVER, WIN, LOOP
    }
    private Dictionary<Sound, float> soundTimeDictionary;
    private GameObject oneShotGameObject;
    private GameObject loopGameObject;
    private AudioSource oneShotAudioSource;
    private AudioSource loopAudioSource;

    private void Awake()
    {
      Initialize();
      PlaySoundLoop(Sound.LOOP);
    }
    public void Initialize()
    {
      soundTimeDictionary = new Dictionary<Sound, float>();
      soundTimeDictionary[Sound.PLAYERMOVE] = 0;

    }
    public SoundAudioClip[] soundAudioClipArray;

    public void PlaySound(Sound sound, Vector3 position)
    {

      if (CanPlaySound(sound))
      {
        GameObject soundObj = new GameObject("Sound");
        soundObj.transform.position = position;
        AudioSource audioSource = soundObj.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);

        audioSource.Play();
        Object.Destroy(soundObj, audioSource.clip.length);
      }
    }

    /// <summary>
    /// Takes a Sound type and plays the associated audioclip in a one shot.
    /// </summary>
    /// <param name="sound">Sound enum</param>
    public void PlaySound(Sound sound)
    {
      if (CanPlaySound(sound))
      {
        if (oneShotGameObject == null)
        {
          oneShotGameObject = new GameObject("One Shot found");
          oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }

        oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        // Destroy(soundObj, audioSource.clip.length);
      }

    }
    public void PlaySoundLoop(Sound sound)
    {
      if (CanPlaySound(sound))
      {
        if (loopGameObject == null)
        {
          oneShotGameObject = new GameObject("One Shot found");
          oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }
        oneShotAudioSource.clip = GetAudioClip(sound);
        oneShotAudioSource.loop = true;
        oneShotAudioSource.Play();
        // Destroy(soundObj, audioSource.clip.length);
      }

    }
    private bool CanPlaySound(Sound sound)
    {
      switch (sound)
      {
        default:
          return true;
        case Sound.PLAYERMOVE:
          if (soundTimeDictionary.ContainsKey(sound))
          {
            float lastTimePlayed = soundTimeDictionary[sound];
            float playerMoveTimerMax = .1f;
            if (lastTimePlayed + playerMoveTimerMax < Time.time)
            {
              soundTimeDictionary[sound] = Time.time;
              return true;
            }
            else
            {
              return false;
            }
          }
          else
          {
            return true;
          }
          //break;
      }
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