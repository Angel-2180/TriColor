using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManager;

    private List<GameEvent> events;

    void Awake()
    {
        if (eventManager == null)
        {
            eventManager = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        events = new List<GameEvent>();
        foreach (Transform child in transform)
        {
            events.Add(child.GetComponent<GameEvent>());
        }
        StartDelay();
    }

    public void StartDelay()
    {
        StartCoroutine(EventDelay());
    }

    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(10);
        events[Random.Range(0, events.Count)].StartEvent();
    }
}
