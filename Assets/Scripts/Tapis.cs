using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapis : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.eulerAngles += Vector3.up * Time.fixedDeltaTime * speed;
    }
}
