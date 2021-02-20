using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SPACE.UI
{
  public class PlayerHUD : MonoBehaviour
  {
    [SerializeField] Text ui_TEXT;

    private void Start()
    {
      ui_TEXT.text = "x0";

    }
    public void AlienCountUpdate(int value){
      string newText = 'X' + value.ToString();
      ui_TEXT.text = newText;
    }


  }

}