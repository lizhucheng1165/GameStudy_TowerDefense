using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventBusType
{
    GAMESTART, WAVE_START, WAVE_STOP, BREAKTIME_START, TIMER_END
}

public class EventBus : MonoBehaviour
{
    private static readonly IDictionary<EventBusType, List<UnityEvent>>
    Events = new Dictionary<EventBusType, List<UnityEvent>>();

    public static void Subscribe(EventBusType eventType, UnityAction listener)
    {
        List<UnityEvent> eventList;
        if (Events.TryGetValue(eventType, out eventList))
        {
            eventList.Add(new UnityEvent());
            eventList[eventList.Count - 1].AddListener(listener);
        }
        else
        {
            eventList = new List<UnityEvent>();
            eventList.Add(new UnityEvent());
            eventList[0].AddListener(listener);
            Events.Add(eventType, eventList);
        }
    }

    public static void UnSubscribe(EventBusType eventType, UnityAction listener)
    {
        List<UnityEvent> eventList;

        if (Events.TryGetValue(eventType, out eventList))
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                eventList[i].RemoveListener(listener);
            }
        }
    }

    public static void Publish(EventBusType eventType)
    {
        List<UnityEvent> eventList;

        if (Events.TryGetValue(eventType, out eventList))
        {
            foreach (UnityEvent evt in eventList)
            {
                evt.Invoke();
            }
        }
    }
}
