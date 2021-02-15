using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SPACE.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        TMP_Text title;


        private void Start()
        {
            StartCoroutine(TitleGlow());
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        IEnumerator TitleGlow()
        {
            while(SceneManager.GetActiveScene().name == "MainMenu")
            {
                title.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1);
                yield return new WaitForSeconds(5);
                title.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, .75f);
                yield return new WaitForSeconds(8);
                title.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, .5f);


            }
        }
    }
}
