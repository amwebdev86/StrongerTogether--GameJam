﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Aliens;
using SPACE.Utils;

namespace SPACE.Players
{
  public class Player : MonoBehaviour
  {
    //Transform _PlayerTrans;
    [SerializeField] Transform _SpawnPoint;
    [SerializeField] PlayerData playerData;
    [SerializeField] FloatVariable playerHealthCurrent;
    [SerializeField] FloatVariable playerScore;
    [SerializeField] FloatVariable rescuedCount;
    //[SerializeField] FloatVariable playerCurrentHealth;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.V))
      {
        DamagePlayer(10);
      }
    }
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

    private void Start()
    {
      playerHealthCurrent.Value = playerData.playerHealthMax.Value;
    }

    /// <summary>
    /// Removes each attached alien in players alienList.
    /// </summary>
    public void PlayerFallSequence()
    {

      //GameManager.Instance.DamagePlayer(20);
      transform.position = _SpawnPoint.position;
    }



    /// <summary>
    /// Sets all aliens currently in the player's list movement Jointment to false;
    /// </summary>
    public void UnjoinAlien(Alien alien)
    {
      if (alien.IsJoined)
      {
        alien.IsJoined = true;
        rescuedCount.Value--;
      }
      else
      {
        return;
      }


    }

    public void JoinAlien(Alien alien)
    {
      if (!alien.IsJoined)
      {
        alien.IsJoined = true;
        rescuedCount.Value++;
      }
      else
      {
        return;
      }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "Alien")
      {
        Alien alien = other.GetComponent<Alien>();
        if (alien != null)
        {
          JoinAlien(alien);

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