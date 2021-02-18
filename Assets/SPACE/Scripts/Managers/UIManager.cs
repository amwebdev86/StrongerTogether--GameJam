using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE.Utils;
using SPACE.UI;
namespace SPACE.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] HealthBar healthBarDisplay;
        // Start is called before the first frame update
        void Start()
        {
            if (!healthBarDisplay)
                healthBarDisplay = GetComponentInChildren<HealthBar>();

        }

        public void SetInitialHealth(int amount)
        {
            healthBarDisplay.SetMaxHealth(amount);

        }
        public void UpdatePlayerHealth(int health)
        {
            healthBarDisplay.SetHealth(health);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}