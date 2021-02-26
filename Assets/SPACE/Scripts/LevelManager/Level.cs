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
    public FloatVariable maxAlienCount;
    public FloatVariable maxScore;
    public FloatVariable score;
    public FloatVariable remaingAliens;
    public void InitLevelData()
    {
      remaingAliens = maxAlienCount;
    }
    public void DecrementLevelAlienCount() => remaingAliens.Value--;
    public void IncrementLevelAlienCount() => remaingAliens.Value++;

    public void UpdateScore(float value)
    {
      score.Value = value;
      //UpdateRemaing((int)score.Value);
    }
    // void UpdateRemaing(int value)
    // {
    //   remaingAliens = (int)maxScore.Value - value;
    //   Debug.Log(remaingAliens);
    // }
  }

}