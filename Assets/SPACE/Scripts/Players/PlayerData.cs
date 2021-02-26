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
    public float currentScore = 0;
    public List<AlienData> alienList = new List<AlienData>();

    private void OnEnable()
    {


    }
    private void OnDisable()
    {



    }
    public void InitHealth()
    {
      playerHealthCurrent.Value = playerHealthMax.Value;

    }

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
      playerHealthCurrent.Value -= amount;
      Debug.Log("Damaged player");
      if (playerHealthCurrent.Value <= 0)
      {
        Debug.LogWarning("Call Gameover event Listener");
        return;
      }
    }

  }
}