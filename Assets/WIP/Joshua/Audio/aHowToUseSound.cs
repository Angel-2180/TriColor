using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aHowToUseSound : MonoBehaviour
{
    public AudioSource source;
    public SO_AudioEvent sound;

    private void Start()
    {
        YourFunction();
    }

    public void YourFunction()
    {
        sound.Play(source);
    }
        
}
