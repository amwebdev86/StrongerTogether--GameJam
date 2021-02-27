using System;
using System.Collections;
using System.Collections.Generic;
using SPACE.Sounds;
using SPACE.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SPACE.Menus
{
  public class OptionsMenu : MonoBehaviour
  {
    [SerializeField] FloatReference volume;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioData audioData;
    [SerializeField] AudioSource source;

    private void OnEnable()
    {
      volume.UseConstant = false;
      volumeSlider.value = volume.Value;

    }
    private void Start()
    {
      //throw new NullReferenceException();
      try
      {
        source = FindObjectOfType<AudioSource>();

      }
      catch (NullReferenceException err)
      {
        Debug.LogError(err);
        source = new GameObject("AudioManager").AddComponent<AudioSource>();

      }

    }
    private void Update()
    {
      audioData.AudioVolUpdate(volumeSlider.value, source);
    }


  }
}
