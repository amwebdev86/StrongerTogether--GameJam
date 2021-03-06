using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Aliens;
using SPACE.Utils;

namespace SPACE.Players
{
  public class Player : MonoBehaviour
  {
    //Transform _PlayerTrans;
    [SerializeField] Transform spawnPos;
    [SerializeField] PlayerData playerData;
    [SerializeField] FloatVariable playerHealthCurrent;



    [SerializeField] FloatVariable playerScore;
    [SerializeField] FloatVariable rescuedCount;


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
      rescuedCount.Value = 0;
    }

    /// <summary>
    /// Removes each attached alien in players alienList.
    /// </summary>
    public void PlayerFallSequence()
    {

      //GameManager.Instance.DamagePlayer(20);
      transform.position = spawnPos.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag == "Enemy")
      {
       
        Debug.Log("Hit the enemy");
        DamagePlayer(10);
      }
    }



  }

}