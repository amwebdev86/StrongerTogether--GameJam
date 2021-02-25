using System.Collections;
using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.Menus
{
  public enum MenuType
  {
    MainMenu,
    PauseMenu,
    OptionsMenu
  }
  [CreateAssetMenu(fileName = "Menu Scene", menuName = "GalacticBond/Levels/Menu")]
  public class Menu : GameScene
  {
    MenuType typeOfMenu;
  }

}