using UnityEngine;
using UnityEngine.Events;

namespace SPACE.Events
{
  public class GameEventListener : MonoBehaviour
  {
    public GameEventSO EventSO;// The game event instance to register to
    public UnityEvent Response;

    /// <summary>
    /// Invokes the unity event.
    /// </summary>
    public void EventRaised()
    {
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
