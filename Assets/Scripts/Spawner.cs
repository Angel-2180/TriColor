using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public static Spawner current;

    public ObjectInstance Instance;
    public List<Trash> trashList;
    private float currentDelay;
    public float spawnDelay;

    private void Awake()
    {
        current = this;
        spawnDelay = 3;
        StartCoroutine(UpdateSpawnDelay());
    }

    void FixedUpdate()
    {
        if(currentDelay <= 0)
        {
            currentDelay = spawnDelay;

            var newInstance = Instantiate(Instance);
            newInstance.transform.SetParent(transform);
            newInstance.Identity = trashList[Random.Range(0, trashList.Count)];
            newInstance.CreateIdentity();
            newInstance.transform.position = Path.path.GetPoints()[0];
        }
        else
        {
            currentDelay -= Time.fixedDeltaTime;
        }
    }

    IEnumerator UpdateSpawnDelay()
    {
        yield return new WaitForSeconds(9);
        spawnDelay = Mathf.Clamp(spawnDelay - 0.75f, 1, 999);
        StartCoroutine(UpdateSpawnDelay());
    }
}