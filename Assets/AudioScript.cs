using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        src.clip = clip;
        src.Play();
    }

}
