using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;
using SPACE.Aliens;

namespace SPACE.Players{
  [CreateAssetMenu(fileName = "PlayerData", menuName = "GalacticBond/Players/PlayerData", order = 0)]
  public class PlayerData : ScriptableObject
  {
    public FloatReference playerId;
    public FloatReference playerHealth;

    public List<AlienData> alienList = new List<AlienData>();

    public void AddAlien(AlienData alien)
    {
      if (alien == null)
      {
        return;

      }
      alienList.Add(alien);
    }
    public void RemoveAlien(AlienData alien)
    {
      if (alien == null)
      {
        return;

      }
      AlienData alientToRemove = alienList.Find(a => a.alienId == alien.alienId);
      alienList.Remove(alientToRemove);


    }

    public void DamagePlayer(float amount)
    {
      if (playerHealth.Value <= 0) return;
      playerHealth.Variable.Value = amount;
    }

  }
}