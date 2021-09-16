using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabledeCuisson : MonoBehaviour
{
    public AudioClip[] dammage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = dammage[Random.Range(0, dammage.Length)];
            audioSource.volume = 0.4f;
            audioSource.Play();
            Destroy(audioSource, 1.0f);
        }
    }
}
