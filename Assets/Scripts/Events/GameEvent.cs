using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public virtual void StartEvent()
    {
    }

    public virtual void EndEvent()
    {
        print("???");
        EventManager.eventManager.StartDelay();
    }
}
