using System.Collections;
using System.Collections.Generic;
using SPACE.Utils;
using UnityEngine;

namespace SPACE.LevelManager
{
  [CreateAssetMenu(fileName = "NewLevel", menuName = "GalacticBond/Levels/New Level")]
  public class Level : GameScene
  {
    [Header("Level Specific")]
    public FloatReference maxAlienCount;
    public FloatReference currAlienCount;
    public FloatReference maxScoreRef;
    [SerializeField] FloatReference remainingAliensRef;
    [SerializeField] FloatReference currlevelScoreRef;
    //public FloatVariable playerScoreVar;//from playerdata
    //public FloatVariable remaingAliens;
    public void InitLevelData()
    {

    }
    // public void DecrementLevelAlienCount() => remaingAliens.Value--;
    // public void IncrementLevelAlienCount() => remaingAliens.Value++;

    public void UpdateScore(float value)
    {
     // score.Value = value;
      //UpdateRemaing((int)score.Value);
    }
    // void UpdateRemaing(int value)
    // {
    //   remaingAliens = (int)maxScore.Value - value;
    //   Debug.Log(remaingAliens);
    // }
  }

}