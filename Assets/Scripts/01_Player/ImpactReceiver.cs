using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReceiver : MonoBehaviour
{
    public float mass = 3.0F; // defines the character mass
    public float explosionPower = 100;

    private Vector3 impact = Vector3.zero;
    private CharacterController character;

    public GameObject hitParticle;

    public AudioClip[] hitSound;
    public AudioClip punchSound;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2F)
            character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.name != gameObject.name)
        {
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            AddImpact(transform.position - other.transform.position, explosionPower);
            StartCoroutine(ClearImpact());

            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitSound[Random.Range(0, hitSound.Length)];
            audioSource2.clip = punchSound;
            audioSource.volume = 0.2f;
            audioSource2.volume = 0.2f;
            audioSource.Play();
            audioSource2.Play();
            Destroy(audioSource, 1.0f);
            Destroy(audioSource2, 1.0f);
        }
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0)
            dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    IEnumerator ClearImpact()
    {
        yield return new WaitForSeconds(1f);
        impact = Vector3.zero;
    }
}