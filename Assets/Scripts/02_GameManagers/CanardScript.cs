using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanardScript : MonoBehaviour
{
    public AudioClip clip;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = 0.35f;
            audioSource.Play();
            Destroy(audioSource, 1.0f);
        }
    }
}
