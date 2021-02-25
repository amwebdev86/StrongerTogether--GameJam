﻿using System.Collections;
using System.Collections.Generic;
using SPACE.LevelManager.Sounds;
using UnityEngine;

namespace SPACE.Utils
{
  public class GameScene : ScriptableObject
  {
    [Header("Information")]
    public string sceneName;
    public string shortDescription;
    [Header("Sounds")]
    public SimpleAudioEvent audioManager;
  }
}
