using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Poubelle : MonoBehaviour
{
    public trashTypes poubelleType;

    public bool isClosed = false;

    public int clickCounter = 0;
    public int minimumClicks = 10;
    public int maximumClicks = 15;
    public int clickToDo;

    public Transform doorLeft;
    public Transform doorRight;

    private Vector3 startPos;
    private Vector3 startRot;

    private void Awake()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;
        OpenTrash(3);
    }

    public void OpenTrash(float delay)
    {
        if (doorLeft || doorRight)
        {
            doorLeft.DOLocalMoveZ(-0.8f, 2).SetEase(Ease.OutBounce).SetDelay(delay);
            doorRight.DOLocalMoveZ(0.8f, 2).SetEase(Ease.OutBounce).SetDelay(delay);

            doorLeft.GetChild(0).GetComponent<ParticleSystem>().Play();
            doorLeft.GetChild(1).GetComponent<ParticleSystem>().Play();

            doorRight.GetChild(0).GetComponent<ParticleSystem>().Play();
            doorRight.GetChild(1).GetComponent<ParticleSystem>().Play();
        }
        if(poubelleType != trashTypes.Cat)
        {
            GetComponentInChildren<Light>().enabled = true;
        }
    }

    public void CloseTrash()
    {
        isClosed = true;
        doorLeft.DOLocalMoveZ(0, 2).SetEase(Ease.OutBounce);
        doorRight.DOLocalMoveZ(0, 2).SetEase(Ease.OutBounce);
        GetComponentInChildren<Light>().enabled = false;
        GetComponentInChildren<AudioInstance>().PlayAudio(4);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isClosed)
        {
            if (!other.GetComponent<ObjectInstance>())
            {
                return;
            }
            var collidItem = other.GetComponent<ObjectInstance>();

            if (collidItem.GetComponent<PathFollower>().grabed)
            {
                return;
            }

            collidItem.GetComponent<PathFollower>().toKill = true;
            collidItem.GetComponent<Collider>().enabled = false;
            collidItem.transform.DOShakeRotation(10, 90, 1);
            collidItem.transform.DOJump(transform.Find("JumpPos").position, 5, 1, 0.5f).SetDelay(0.25f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                if (collidItem.Identity.type == poubelleType)
                {
                    if(collidItem.Identity.type == trashTypes.Cat)
                    {
                        CatEvent.current.isDestroyed = true;
                        GetComponentInChildren<AudioInstance>().PlayAudio(2);
                    }
                    else
                    {
                        GetComponentInChildren<AudioInstance>().PlayAudio(0);
                    }
                    Score.score.PlayerScore += collidItem.Identity.score;
                    ParticleManager.manager.PlayParticle(transform.Find("JumpPos").position, 0);
                    Destroy(collidItem.gameObject);
                }
                else if (collidItem.Identity.type != poubelleType)
                {
                    if (collidItem.Identity.type == trashTypes.Cat)
                    {
                        CatEvent.current.isDestroyed = true;
                        GetComponentInChildren<AudioInstance>().PlayAudio(3);
                    }
                    else
                    {
                        GetComponentInChildren<AudioInstance>().PlayAudio(1);
                    }
                    Score.score.PlayerScore -= 400;
                    ParticleManager.manager.PlayParticle(transform.Find("JumpPos").position, 1);
                    Destroy(collidItem.gameObject);
                }
            });
        }
    }

    private void OnMouseDown()
    {
        if (isClosed)
        {
            clickCounter += 1;

            ParticleManager.manager.PlayParticle(transform.Find("JumpPos").position, 2);
            GetComponentInChildren<AudioInstance>().PlayAudio(2);

            transform.DOJump(startPos, Random.Range(0.5f, 2f), 1, 0.5f).SetEase(Ease.OutBack);
            transform.DOLocalRotate(startRot + new Vector3(Random.Range(Random.Range(-20f, -10f), Random.Range(10f, 20f)), 0, 0), 0.15f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                transform.DOLocalRotate(startRot, 0.15f).SetEase(Ease.OutSine);
            });
            if (clickCounter >= clickToDo)
            {
                isClosed = false;
                OpenTrash(0);
                TrashEvent.EventTrash.EndEvent();
                clickCounter = 0;
            }
        }
    }
}