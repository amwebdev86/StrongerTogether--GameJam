using SPACE.Utils;
using UnityEngine;


namespace SPACE.Aliens
{
  [CreateAssetMenu(fileName = "AlienData", menuName = "GalacticBond/Aliens/AlienData", order = 0)]
  public class AlienData : ScriptableObject
  {
    public int alienId;
    public FloatReference alienHealth;
    public bool isJoinded;
    public void DamageAlien(float amount)
    {
      alienHealth.Variable.Value -= amount;

    }
    private void OnDisable()
    {
      isJoinded = false;
    }
    private void OnEnable()
    {
      if (isJoinded) isJoinded = false;
    }


  }
}

