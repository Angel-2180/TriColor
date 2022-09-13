using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Event_Trigger : MonoBehaviour
{
    public UnityEvent EventToInvoke;
    bool  onlyPlayOnce = true;
    private void OnTriggerEnter(Collider other)
    {
        if(onlyPlayOnce == true)
        {
            if (other.gameObject.tag == "Player")
            {
                EventToInvoke.Invoke();
            }
        }
        else 
        {
            onlyPlayOnce = false;
            gameObject.SetActive(false);
        }
    }
}
