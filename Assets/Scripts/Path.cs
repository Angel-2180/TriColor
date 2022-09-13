using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Path : MonoBehaviour
{
    public static Path path;
    [SerializeField] private float speed = 15;

    private void Awake()
    {
        if(path == null)
        {
            path = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3[] GetPoints()
    {
        List<Vector3> childs = new List<Vector3>();
        foreach(Transform child in transform)
        {
            childs.Add(child.position);
        }
        return childs.ToArray();
    }

    public float GetConvoyeurSpeed()
    {
        return speed;
    }
}
