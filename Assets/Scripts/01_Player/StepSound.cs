using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioClip[] stepsSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = stepsSound[Random.Range(0, stepsSound.Length)];
            audioSource.volume = 0.1f;
            audioSource.pitch = 1.0f;
            audioSource.Play();
            Destroy(audioSource, 5.0f);
        }

    }
}
