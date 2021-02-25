using System.Collections;
using System.Collections.Generic;
using SPACE.LevelManager;
using SPACE.Menus;
using UnityEngine;

namespace SPACE.Utils
{
  [CreateAssetMenu(fileName = "SceneDB", menuName = "GalacticBond/Utils/SceneData")]
  public class SceneData : ScriptableObject
  {
    public List<Level> levels = new List<Level>();
    public List<Menu> menus = new List<Menu>();
    public int currentLevelIndex = 1;


  }
}
