using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSetting : ScriptableObject
{
  [SerializeField] float jumpForce = 400f;
  [Range(0, 1)] [SerializeField] float crouchSpeed;
  [Range(0, .3f)] [SerializeField] float movementSmoothing = .05f;
  [SerializeField] bool airControl = false;
  [SerializeField] LayerMask groundMask;
  [SerializeField] Transform groundCheck;
  [SerializeField] Transform ceilingCheck;
  [SerializeField] Collider2D crouchDisableCollider;
  [SerializeField] bool flipSprite = false;
}
