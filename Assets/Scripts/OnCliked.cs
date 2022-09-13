using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCliked : MonoBehaviour
{
    [SerializeField] private UnityEvent onClicked;
    [SerializeField] private UnityEvent onDrag;
    [SerializeField] private UnityEvent onRealease;
    [SerializeField] private UnityEvent onOver;
    [SerializeField] private UnityEvent onExit;

    private void OnMouseDown()
    {
        onClicked.Invoke();
    }

    private void OnMouseDrag()
    {
        onDrag.Invoke();
    }

    private void OnMouseUp()
    {
        onRealease.Invoke();
    }

    private void OnMouseOver()
    {
        onOver.Invoke();
    }

    private void OnMouseExit()
    {
        onExit.Invoke();
    }
}
