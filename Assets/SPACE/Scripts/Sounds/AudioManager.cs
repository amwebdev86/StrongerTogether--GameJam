using UnityEngine;

namespace SPACE.Sounds
{
  public class AudioManager : MonoBehaviour
  {
    [SerializeField] AudioData audioData;
    AudioSource source;
    private void Start()
    {
      source = GetComponent<AudioSource>();
      source.clip = audioData.musicClip;
      audioData.Play(source);
    }
  }
}