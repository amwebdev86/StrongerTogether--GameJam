using System.Collections;
using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.LevelManager
{
  [CreateAssetMenu(fileName = "NewLevel", menuName = "GalacticBond/Levels/New Level")]
  public class Level : GameScene
  {
    [Header("Level Specific")]
    public int alienCount;
    public int followers = 0;
  }

}