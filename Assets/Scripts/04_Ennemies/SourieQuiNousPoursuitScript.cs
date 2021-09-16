using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourieQuiNousPoursuitScript : MonoBehaviour
{
    public float speed;

    public float distance;

    private Rigidbody rb;
    private EnnemiSourisCalcul sourisCalcul;

    public int indexWayPoints = 0;

    public GameObject[] wayPoints;
    public Transform wayPointTarget;

    public AudioClip[] fishfall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sourisCalcul = FindObjectOfType(typeof(EnnemiSourisCalcul)) as EnnemiSourisCalcul;
    }

    void Update()
    {
        if (indexWayPoints <= wayPoints.Length)
        {
            wayPointTarget = wayPoints[indexWayPoints].transform;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, Mathf.Lerp(transform.position.x, sourisCalcul.transform.position.x - distance, 0.02f), sourisCalcul.firstPlayer), wayPointTarget.position.y, wayPointTarget.position.z);

            if (FindObjectOfType<Timer>().gameStart)
            {
                rb.velocity = Vector3.right * speed;
            }

            if (transform.position.x >= wayPointTarget.position.x && wayPointTarget.position.x < wayPoints[wayPoints.Length - 1].transform.position.x)
            {
                indexWayPoints++;
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, transform.position.x, wayPoints[wayPoints.Length - 1].transform.position.x), transform.position.y, transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = fishfall[Random.Range(0, fishfall.Length)];
            audioSource.volume = 0.25f;
            audioSource.pitch = 2;
            audioSource.Play();
            Destroy(audioSource, 1.0f);
        }
    }
}
