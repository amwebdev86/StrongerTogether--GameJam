using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Managers;
using SPACE.Players.Aliens;

namespace SPACE.Players
{
  public class Player : MonoBehaviour
  {
    Transform _PlayerTrans;
    [SerializeField] Transform _SpawnPoint;//currently only used for reseting player after falling.
    List<Alien> alienList;

    /// <summary>
    /// Grabs Player Transform and intiaites a new List of Alien components.
    /// </summary>
    private void Start()
    {
      _PlayerTrans = GetComponent<Transform>();
      alienList = new List<Alien>();
    }
    /// <summary>
    /// Checks that player has not fallen off the level.
    /// </summary>
    //
    private void Update()
    {

      if (_PlayerTrans.position.y <= -9)
      {
        PlayerFallSequence();
      }
    }
    /// <summary>
    /// Removes each attached alien in players alienList.
    /// </summary>
    void PlayerFallSequence()
    {
      SoundManager.Instance.PlaySound(SoundManager.Sound.FALL);
      if (alienList.Count > 0)
      {
        alienList.ForEach(a => RemoveFromPlayer(a));

      }
      GameManager.Instance.DamagePlayer(25);
      _PlayerTrans.position = _SpawnPoint.position;


    }

    /// <summary>
    /// Adds an Alien to the players alienlist.
    /// </summary>
    /// <param name="alien">GameObject containing the Alien script component.</param>
    public void AddAlien(Alien alien)
    {
      alienList.Add(alien);
      SoundManager.Instance.PlaySound(SoundManager.Sound.PLAYERINTERACT);
      GameManager.Instance.UpdatePlayerAlienCount(alienList.Count);
    }
    /// <summary>
    /// Sets Alien movment Joinment to false and removes Alien from the Player's alienList.
    /// </summary>
    /// <param name="alien">GameObject with the Alien Component Attached to it.</param>
    public void RemoveFromPlayer(Alien alien)
    {
      alien.GetComponent<AlienMovement>().isJoined = false;
      alienList.Remove(alien);
      GameManager.Instance.UpdatePlayerAlienCount(alienList.Count);

    }
    /// <summary>
    /// Sets all aliens currently in the player's list movement Jointment to false;
    /// </summary>
    public void UnjoinAliens()
    {
      if (alienList.Count > 0)
      {
        alienList.ForEach(a => a.GetComponent<AlienMovement>().isJoined = false);

      }
    }

    public int AlientListCount()
    {
      return alienList.Count;
    }
  }

}