using UnityEngine;
using SPACE.Utils;

namespace SPACE.LevelManager.Sounds
{
  [CreateAssetMenu(menuName = "GalacticBond/Audio/SimpleAudioEvent", fileName = "AudioEvent")]
  public class SimpleAudioEvent : AudioEvent
  {
    public AudioClip[] clips;
    [Range(0, 20)]
    public float volume;

    public override void Play(AudioSource source)
    {
      if (clips.Length == 0) return;
      source.clip = clips[Random.Range(0, clips.Length)];
      source.volume = 10;
      source.pitch = 2;
      source.Play();

    }
  }

}