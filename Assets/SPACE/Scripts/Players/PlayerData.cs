using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;
using SPACE.Aliens;

namespace SPACE.Players
{
  [CreateAssetMenu(fileName = "PlayerData", menuName = "GalacticBond/Players/PlayerData", order = 0)]
  public class PlayerData : ScriptableObject
  {
    public FloatVariable playerId;
    public FloatVariable playerHealthMax;
    public FloatVariable playerHealthCurrent;
    public FloatVariable currentScore;
    public FloatVariable currentAlienCount;
    public List<AlienData> alienList = new List<AlienData>();


    public void InitPlayerData()
    {
      alienList = new List<AlienData>();
      playerHealthCurrent.Value = playerHealthMax.Value;

    }
    public void PlayerDataUpdate()
    {
      currentAlienCount.Value = alienList.Count;
    }

    public void AddAlien(AlienData alien)
    {
      if (alien == null)
      {
        return;

      }
      alienList.Add(alien);
      currentAlienCount.Value++;
    }
    public void RemoveAlien(AlienData alien)
    {
      if (alien == null)
      {
        return;

      }
      AlienData alientToRemove = alienList.Find(a => a.alienId == alien.alienId);
      alienList.Remove(alientToRemove);
      currentAlienCount.Value--;


    }
    /// <summary>
    /// Damages the player and checks if dead.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>Returns true if the player has died from damage</returns>
    public bool DamagePlayer(float amount)
    {
      playerHealthCurrent.Value -= amount;
      Debug.Log("Damaged player");
      if (playerHealthCurrent.Value <= 0)
      {

        return true;
      }
      return false;
    }

  }
}