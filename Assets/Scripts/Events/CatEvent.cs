using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEvent : GameEvent
{
    public static CatEvent current;
    public ObjectInstance Instance;
    public bool isDestroyed = false;
    public Trash catTrash;


    void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    public override void StartEvent()
    {
        isDestroyed = false;
        Debug.Log("CatEvent");
        var instantiateCat = Instantiate(Instance);
        instantiateCat.transform.SetParent(transform);
        instantiateCat.Identity = catTrash;
        instantiateCat.CreateIdentity();
        instantiateCat.transform.position = Path.path.GetPoints()[0];
    }
}
