using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Truck : MonoBehaviour
{
    private GameObject truck;
    private GameObject phone;
    private GameObject door;
    private GameObject Truck_Door_1;
    private GameObject Truck_Door_2;

    public AudioInstance[] audioInstances;

    private float truckDelay = 0;
    public GameObject[] PathObjects;

    [SerializeField, Tooltip("delay between use of the phone")] private float delay = 80;

    private void Start()
    {
        truck = transform.Find("Truck").gameObject;
        phone = transform.Find("Phone").gameObject;
        door = transform.Find("Door").gameObject;
        Truck_Door_1 = transform.Find("Truck/Camion/Porte_Camion_1").gameObject;
        Truck_Door_2 = transform.Find("Truck/Camion/Porte_Camion_2").gameObject;
        truck.transform.DOMove(PathObjects[0].transform.position, 0);
    }

    private void FixedUpdate()
    {
        truckDelay -= Time.fixedDeltaTime;
        if (CatEvent.current.isDestroyed)
        {
            GoAwayTruck();
        }
    }

    public void ComeTruck()
    {
        if (truckDelay <= 0)
        {
            audioInstances[0].PlayAudio(0);
            door.transform.DOMoveY(5, 5).SetEase(Ease.InOutSine);
            truck.transform.DOMove(PathObjects[1].transform.position, 5).SetDelay(2).OnComplete(() =>
            {
                Truck_Door_1.transform.DORotate(new Vector3(0, -70, 0), 1);
                Truck_Door_2.transform.DORotate(new Vector3(0, 70, 0), 1);
            });
            if (!CatEvent.current.isDestroyed)
            {
                StartCoroutine(GoAway());
            }
            truckDelay = delay;
        }
        else
        {
            Debug.Log("can't summon truck");
        }
    }

    private IEnumerator GoAway()
    {
        yield return new WaitForSeconds(20);
        GoAwayTruck();
        yield return new WaitForSeconds(5);
        audioInstances[0].StopAudio();
    }

    public void GoAwayTruck()
    {
        Truck_Door_1.transform.DORotate(new Vector3(0, -180, 0), 1).SetEase(Ease.InOutSine);
        Truck_Door_2.transform.DORotate(new Vector3(0, 180, 0), 1).SetEase(Ease.InOutSine);
        truck.transform.DOMove(PathObjects[0].transform.position, 5).SetDelay(2).OnComplete(() =>
        {
            door.transform.DOMoveY(0, 5).SetEase(Ease.InOutSine);
        });
    }
}