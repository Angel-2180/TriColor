using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathFollower : MonoBehaviour
{
    private Vector3 oldPosition;
    private Vector3 grabPos;
    public Vector3 grabBoxSize;
    public Vector3 realeaseBoxSize;

    public bool grabed;
    public bool toKill;

    private void Awake()
    {
        GetComponent<BoxCollider>().size = realeaseBoxSize;
        StartFollowPath();
        GetComponentInChildren<TrailRenderer>().enabled = false;
    }

    public void StartFollowPath()
    {
        transform.DOPath(Path.path.GetPoints(), Path.path.GetConvoyeurSpeed(), PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameOver.current._GameOver();
            Destroy(gameObject);
        });
    }

    private void Update()
    {
        if (grabed || toKill)
            return;

        Vector3 direction = (oldPosition - transform.position);

        transform.LookAt(transform.position + direction);

        oldPosition = transform.position;
    }

    private void OnMouseDown()
    {
        grabed = true;
        transform.DOPause();
        grabPos = transform.position;
        GetComponent<BoxCollider>().size = grabBoxSize;
        GetComponentInChildren<TrailRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        if (toKill)
        {
            return;
        }
        GetComponentInChildren<TrailRenderer>().enabled = false;
        GetComponent<BoxCollider>().size = realeaseBoxSize;
        grabed = false;
        transform.DOLookAt(grabPos, 0.5f);
        transform.DOJump(grabPos, 5, 1, 0.5f).SetEase(Ease.OutSine).SetDelay(0.25f).OnComplete(() =>
        {
            transform.DOPlay();
        });
    }
}
