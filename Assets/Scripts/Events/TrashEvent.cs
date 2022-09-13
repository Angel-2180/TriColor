using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEvent : GameEvent
{
    public static TrashEvent EventTrash;
    // private int Timer = 5;

    public Poubelle[] poubelles;
    private Poubelle selectedPoubelle;

    private void Awake()
    {
        if (EventTrash == null)
        {
            EventTrash = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void StartEvent()
    {
        selectedPoubelle = poubelles[Random.Range(0, poubelles.Length)];
        if (!selectedPoubelle)
        {
            return;
        }
        selectedPoubelle.CloseTrash();
        selectedPoubelle.clickToDo = Random.Range(selectedPoubelle.minimumClicks, selectedPoubelle.maximumClicks);
    }
}