using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crefits : MonoBehaviour
{
    public MeshRenderer Image;
    public List<Material> Textures = new List<Material>();

    private void Start()
    {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(Random.Range(3,5));
        int rdn = Random.Range(0, Textures.Count);
        Image.material = Textures[rdn];
        StartCoroutine(ChangeImage());
    }

}
