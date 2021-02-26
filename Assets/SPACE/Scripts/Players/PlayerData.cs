using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;
using SPACE.Aliens;

namespace SPACE.Players
{
  [CreateAssetMenu(fileName = "PlayerData", menuName = "GalacticBond/Players/PlayerData", order = 0)]
  public class PlayerData : ScriptableObject
  {

    public FloatReference playerId;
    public FloatReference playerHealthMax;
    public FloatReference playerHealthCurrent;
    public FloatReference playerScore;
    public FloatReference rescuedCount;



  }
}