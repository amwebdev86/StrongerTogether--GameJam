using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace SPACE.UI
{
  public class PlayerHUD : MonoBehaviour
  {
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text playerFollowerText;



    public string AlienCountUpdate(int value)
    {
      int storedVal = value;
      string newText = storedVal.ToString();
      if (storedVal < 0)
      {
        storedVal = 0;
      }
      playerFollowerText.text = "Followers X" + newText;
      return newText;
    }
    /// <summary>
    /// Updates the level UI text in the center.
    /// </summary>
    /// <param name="value">a number to pass the counter</param>
    /// <param name="msg">Used to display the level</param>
    /// <returns>The message to display</returns>
    public string UpdateLevelUI(int value, string msg)
    {
      int storedVal = value;
      string storedMsg = msg;
      storedMsg.Trim();
      if (storedVal < 0)
      {
        storedVal = 0;
      }
      storedMsg += "Aliens remaining x" + storedVal.ToString().Trim();
      string newText = storedMsg;
      levelText.text = newText;
      return newText;
    }
    public void ToggleLevelText(bool active)
    {
      levelText.gameObject.SetActive(active);
    }

  }

}