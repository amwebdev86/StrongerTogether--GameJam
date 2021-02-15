using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACE.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        //creates multiple verisions to be accessed without initation - morgan
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindOrCreateInstance();
                }
                return _instance;
            }
        }
        private static T _instance;//stores actual instance.

        /// <summary>
        /// Attempts to find a instance of this singleton if one cannot be found a new one is created.
        /// </summary>
        /// <returns>Generic</returns>
        private static T FindOrCreateInstance()
        {
            T instance = GameObject.FindObjectOfType<T>();
            if (instance != null)//found a T instance
            {
                return instance;
            }
            //or create new instance and give it a name.
            //name the singleton
            string name = typeof(T).Name + " Singleton";
            //set gameobject name
            GameObject go = new GameObject(name);
            //create and attach whichever T
            T singletonCompoonent = go.AddComponent<T>();
            return singletonCompoonent;

        }
    }
}
