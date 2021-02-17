using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.LevelManager
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private Vector2 parallaxEffectMultiplier;
       private Transform camTransform;
        private Vector3 lastCameraPositon;
        private void Start()
        {
            camTransform = Camera.main.transform;
            lastCameraPositon = camTransform.transform.position;
        }
        private void LateUpdate()
        {
            Vector3 deltaMovement = camTransform.position - lastCameraPositon;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
            lastCameraPositon = camTransform.position;
        }
    }

}