using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Utils
{
  [CreateAssetMenu(menuName = "GalacticBond/Utils/Singleton", fileName = "SingletonData")]
  public class MySingleton : ScriptableObject
  {
    private static MySingleton _instance;
    public static MySingleton Instance
    {
      get
      {
        if (!_instance)
        {
          _instance = Resources.Load<MySingleton>("Resources/Utils");

        }
        if (!_instance)
        {
          _instance = CreateInstance<MySingleton>();
        }
        return _instance;
      }
    }

  }

}