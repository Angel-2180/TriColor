using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ObjectInstance : MonoBehaviour
{
    public Trash Identity;

    public void CreateIdentity()
    {
        GameObject new_mesh = Instantiate(Identity.mesh);
        new_mesh.transform.SetParent(transform);
        new_mesh.transform.position = Vector3.zero;
        new_mesh.transform.eulerAngles = Vector3.zero;
        switch (Identity.type)
        {
            case trashTypes.Verre:
                GetComponentInChildren<Light>().color = Color.green;
                GetComponentInChildren<TrailRenderer>().startColor = Color.green;
                GetComponentInChildren<TrailRenderer>().endColor = Color.green;
                break;
            case trashTypes.Plastique:
                GetComponentInChildren<Light>().color = Color.blue;
                GetComponentInChildren<TrailRenderer>().startColor = Color.blue;
                GetComponentInChildren<TrailRenderer>().endColor = Color.blue;
                break;
            case trashTypes.Dechets:
                GetComponentInChildren<Light>().color = Color.red;
                GetComponentInChildren<TrailRenderer>().startColor = Color.red;
                GetComponentInChildren<TrailRenderer>().endColor = Color.red;
                break;
            case trashTypes.Carton:
                GetComponentInChildren<Light>().color = Color.yellow;
                GetComponentInChildren<TrailRenderer>().startColor = Color.yellow;
                GetComponentInChildren<TrailRenderer>().endColor = Color.yellow;
                break;
            case trashTypes.Cat:
                GetComponentInChildren<Light>().enabled = false;
                StartCoroutine(MEOW());
                break;
            default:
                break;
        }
    }

    IEnumerator MEOW()
    {
        GetComponentInChildren<AudioInstance>().PlayAudio(1);
        while (true)
        {
            yield return new WaitForSeconds(10);
            GetComponentInChildren<AudioInstance>().PlayAudio(1);
        }
    }

    private void OnDestroy()
    {
        if(Identity.type == trashTypes.Cat)
        {
            CatEvent.current.isDestroyed = false;
            CatEvent.current.EndEvent();
        }
    }
}
