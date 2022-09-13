using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstance : MonoBehaviour
{
    public SO_AudioEvent[] sounds;
    public AudioSource source;

    public void PlayAudio(int index)
    {
        sounds[index].Play(source);
    }

    public void StopAudio()
    {
        source.Stop();
    }

    public void StopFade()
    {

    }
}