using UnityEngine;
using UnityEngine.Events;

namespace AMGame.Core.EventSystem
{
  public class GameEventListener : MonoBehaviour
  {
    public GameEventSO EventSO;
    public UnityEvent Response;

/// <summary>
/// Invokes the unity event.
/// </summary>
    public void EventRaised(){
      Response.Invoke();
    }
    private void OnEnable()
    {
      EventSO.RegisterEventListener(this);
    }
    private void OnDisable()
    {
      EventSO.UnRegisterEventListener(this);
    }


  }
}
