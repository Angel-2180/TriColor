using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Box : MonoBehaviour
{
    int hp;
    public GameObject Box1;
    public GameObject Box2;
    public List<GameObject> BoxInstance = new List<GameObject>();

    private void Start()
    {
        hp = Random.Range(5, 11);
        Debug.Log(hp);
    }

    void OnMouseDown()
    {
        hp --;
        if(hp <= 0)
        {
            Box1.SetActive(false);
            Box2.SetActive(true);
        }
        Debug.Log(hp);
    }
}
