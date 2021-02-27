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
    private void OnEnable()
    {
      maxAlienCount.Value = maxAlienCount.ConstantValue;
    }
    private void OnDisable()
    {
      maxAlienCount.Value = maxAlienCount.ConstantValue;

    }
  }



}