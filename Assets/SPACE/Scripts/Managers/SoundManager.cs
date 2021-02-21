using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Utils;
namespace SPACE.Managers
{

  public class SoundManager : Singleton<SoundManager>
  {

    public AudioClip playerJump;

    public void PlayJumpSound()
    {
      GameObject soundObj = new GameObject("Sound");
      AudioSource audioSource = soundObj.AddComponent<AudioSource>();
      audioSource.PlayOneShot(playerJump);
    }
  }

}