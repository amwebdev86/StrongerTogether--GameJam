using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Managers;

namespace SPACE.Player
{
  public class Player : MonoBehaviour
  {
    Transform _PlayerTrans;
    [SerializeField] Transform _SpawnPoint;//currently only used for reseting player after falling.
    [SerializeField] int _AlienCount = 0;
    public int AlienCount
    {
      get
      {
        return _AlienCount;
      }
    }

    private void Start()
    {
      _PlayerTrans = GetComponent<Transform>();
    }
    /// <summary>
    /// Checks that player has not fallen off the level.
    /// </summary>
    private void Update()
    {
      if (_PlayerTrans.position.y <= -9)
      {
        PlayerFallSequence();
      }
    }

    void PlayerFallSequence()
    {
      GameManager.Instance.DamagePlayer(20);
      _PlayerTrans.position = _SpawnPoint.position;


    }
    public void AddAlienCount()
    {
      _AlienCount += 1;
    }
    public void SubtractAlienCount()
    {
      if (_AlienCount <= 0)
      {
        _AlienCount = 0;
        return;
      }
      _AlienCount -= 1;
    }
  }

}