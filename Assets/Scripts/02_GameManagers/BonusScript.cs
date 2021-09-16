using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public float affectSpeed;
    public float affectTime;

    public float speedTurn;

    private ParticleSystem particle;

    public AudioClip bonusSound;
    public AudioClip[] sushiSound;

    private void Start()
    {
        transform.localRotation = new Quaternion(-10, -10, -10, 5.7f);

        particle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, speedTurn * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
            audioSource.clip = bonusSound;
            audioSource2.clip = sushiSound[Random.Range(0, sushiSound.Length)];
            audioSource.volume = 0.1f;
            audioSource2.volume = 0.5f;
            audioSource.Play();
            audioSource2.Play();
            Destroy(audioSource, 1.0f);
            Destroy(audioSource2, 1.0f);

            StartCoroutine(GiveBonus(other));
            
        }
    }

    IEnumerator GiveBonus(Collider player)
    {
        player.GetComponent<PlayerCharacterController>().bonusActive = true;

        //désactivation du Bonus
        player.GetComponent<PlayerCharacterController>().bonusParticle.SetActive(true);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particle.Stop();

        PlayerCharacterController pcc = player.GetComponent<PlayerCharacterController>();
        float iniSpeed = pcc.iniSpeed;
        pcc.speed = pcc.speed* affectSpeed;
        yield return new WaitForSeconds(affectTime);
        player.GetComponent<PlayerCharacterController>().bonusParticle.SetActive(false);
        StartCoroutine(ReductSpeed(pcc,iniSpeed));
    }

    IEnumerator ReductSpeed(PlayerCharacterController pcc,float iniSpeed)
    {
        if (pcc.speed > iniSpeed)
        {
            pcc.speed = Mathf.Clamp(0.9f * pcc.speed, iniSpeed, pcc.speed);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ReductSpeed(pcc, iniSpeed));
        }
        else
        {
            pcc.speed = iniSpeed;
            pcc.bonusActive = false;
            Destroy(gameObject);
        }
    }


}
