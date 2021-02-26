using SPACE.Utils;
using UnityEngine;


namespace SPACE.Aliens
{
  [CreateAssetMenu(fileName = "AlienData", menuName = "GalacticBond/Aliens/AlienData", order = 0)]
  public class AlienData : ScriptableObject
  {
    public int alienId;
    [Header("Health")]
    public FloatReference maxAlienHealth;
    public FloatReference currAlienHealth;
  }
}

