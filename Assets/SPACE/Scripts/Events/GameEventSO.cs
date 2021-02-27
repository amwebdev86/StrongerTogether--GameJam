
using System.Collections.Generic;
using UnityEngine;


namespace SPACE.Events
{
  [CreateAssetMenu(fileName = "GameEventsSO", menuName = "AMGame/Events/GameEventsSO", order = 0)]
  public class GameEventSO : ScriptableObject
  {
    List<GameEventListener> listeners = new List<GameEventListener>();
    public void Raise()
    {
      for (int i = listeners.Count - 1; i >= 0; i--)
      {
        listeners[i].EventRaised();
      }
    }

    public void RegisterEventListener(GameEventListener listener)
    {
      if (!listeners.Contains(listener))
      {

        listeners.Add(listener);
      }
      else
      {
        Debug.LogError("Unable to RegisterEvent Event already registered");
        return;
      }

    }

    public void UnRegisterEventListener(GameEventListener listener){
      if(listeners.Contains(listener)){
        listeners.Remove(listener);
      }
    }

  }


}