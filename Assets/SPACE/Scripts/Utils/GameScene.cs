using System.Collections;
using System.Collections.Generic;
using SPACE.Sounds;
using UnityEngine;

namespace SPACE.Utils
{
  public class GameScene : ScriptableObject
  {
    [Header("Information")]
    public string sceneName;
    public string shortDescription;
    [Header("Sounds")]
    public AudioData audioManager;
  }
}
