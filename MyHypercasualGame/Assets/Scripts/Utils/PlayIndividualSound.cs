using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIndividualSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;

    public void PlaySound()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
