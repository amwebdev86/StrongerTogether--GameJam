using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Utils;

namespace SPACE.Controller
{
  [CreateAssetMenu(menuName = "GalacticBond/Controllers/ControlSetting", fileName = "ControlSetting")]
  public class ControlSetting : ScriptableObject
  {
    public FloatReference jumpForce;
    public FloatReference crouchSpeed;
    public FloatReference movementSmoothing;
    

  }

}