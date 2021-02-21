using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Players
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject target;
        [SerializeField]
        Vector3 offset; //offset distance between the player and camera
        public Vector3 RectOffset{
            get{
        return offset;
      }
            set{
                offset = value;
            }
        }

        void Start()
        {
            if (!target)
            {
                Debug.LogWarning("No Camera Target... Setting it to gameobject tagged 'Player'");
                target = GameObject.FindGameObjectWithTag("Player");
            }
            //offset = transform.position - target.transform.position *.5f;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            //position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = target.transform.position + offset;
        }
    }

}