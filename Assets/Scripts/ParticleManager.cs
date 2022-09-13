using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager manager;

    public ParticleSystem[] particles;

    private void Awake()
    {
        if(manager == null)
        {
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayParticle(Vector3 position, int index)
    {
        GameObject newParticle = Instantiate(particles[index], transform).gameObject;
        newParticle.transform.position = position;
    }
}
