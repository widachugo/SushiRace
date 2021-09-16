using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{
    public AudioClip[] deathSound;
    public AudioClip[] deathCollisionSound;

    public void DeathSong()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = deathSound[Random.Range(0, deathSound.Length)];
        audioSource.volume = 1.0f;
        audioSource.Play();
        Destroy(audioSource, 1.0f);

        AudioSource audioSourceCol = gameObject.AddComponent<AudioSource>();
        audioSourceCol.clip = deathCollisionSound[Random.Range(0, deathCollisionSound.Length)];
        audioSourceCol.volume = 0.15f;
        audioSourceCol.Play();
        Destroy(audioSourceCol, 1.0f);
    }
}
