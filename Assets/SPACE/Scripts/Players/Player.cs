using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Aliens;
using SPACE.Utils;

namespace SPACE.Players
{
  public class Player : MonoBehaviour
  {
    Transform _PlayerTrans;
    [SerializeField] Transform _SpawnPoint;

    [SerializeField] PlayerData playerData;
    [SerializeField] FloatVariable playerCurrentHealth;

    //TODO Add this to start and instantiate new list.

    // public void InitPlayerHealth()
    // {
    //   playerCurrentHealth.Value = playerData.playerHealthMax.Value;

    // }
    private void Start()
    {
      _PlayerTrans = GetComponent<Transform>();

      playerData.alienList = new List<AlienData>();
      // InitPlayerHealth();
     // playerData.InitHealth();

    }
    public void DamagePlayer(float amount)
    {
      playerCurrentHealth.Value -= amount;
    }

    /// <summary>
    /// Removes each attached alien in players alienList.
    /// </summary>
    public void PlayerFallSequence()
    {
      if (playerData.alienList.Count > 0)
      {
        playerData.alienList.ForEach(a => playerData.RemoveAlien(a));

      }
      //GameManager.Instance.DamagePlayer(20);
      _PlayerTrans.position = _SpawnPoint.position;
    }



    /// <summary>
    /// Sets all aliens currently in the player's list movement Jointment to false;
    /// </summary>
    public void UnjoinAliens()
    {
      if (playerData.alienList.Count > 0)
      {
        playerData.alienList.ForEach(a =>
        {
          a.isJoinded = false;
          playerData.RemoveAlien(a);

        });


      }

    }

    public void JoinAlien(AlienData alien)
    {
      if (alien.isJoinded)
      {
        return;
      }
      alien.isJoinded = true;
      playerData.alienList.Add(alien);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "Alien")
      {
        AlienData aliendata = other.GetComponent<Alien>().GetAlienData();
        if (aliendata != null)
        {
          JoinAlien(aliendata);

        }
        else if (other.gameObject.tag == "Enemy")
        {
          // var enemy =
        }
        else
        {
          Debug.LogError("Could not get alien data");
        }
      }
    }


  }

}