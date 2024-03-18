using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;

    public float timeToHide = 1f;

    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == compareTag)
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if(graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke("HideObject", timeToHide);
        OnCollect();
    } 

    private void HideObject()
    {
        gameObject.SetActive(false);
        
    }
    protected virtual void OnCollect()
    {
        if(particleSystem != null)
        {
            particleSystem.Play();

            if(audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
   
}
