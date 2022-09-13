using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Camera cam;
    [SerializeField] public float speed = 10;
    [SerializeField] public float Offset = 10;
    public LayerMask Layer;
    private bool test;
    public AudioSource source;
    public SO_AudioEvent sound;
    TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        cam = Camera.main;
    }
    void OnMouseDown()
    {
        sound.Play(source);
        test = true;
    }
    void OnMouseDrag()
    {
        trail.enabled = true;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, ray.direction * 1000, Color.red);
        RaycastHit hit;

        #region raph
        Vector3 targetPoint;
        if (test)
        {
            if (Physics.Raycast(cam.transform.position, ray.direction * 1000, out hit, 1000, Layer))// && hit.collider.gameObject.layer == Layer)
            {
                targetPoint = hit.point;
                transform.position = Vector3.MoveTowards(transform.position, hit.point + new Vector3(0, Offset, 0), speed * Time.deltaTime);
            }
        }
        #endregion

    }
    private void OnMouseUp()
    {
        test = false;
        trail.enabled = false;
    }

}

