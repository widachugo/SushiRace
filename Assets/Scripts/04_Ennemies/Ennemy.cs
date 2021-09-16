using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ennemy : MonoBehaviour
{
    public float speed;
    public float actionRayon;

    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;
    private GameObject[] players;
    private float[] distancePlayer;
    private GameObject target = null;
    private float nearest;
    private float dist;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player");
        distancePlayer = new float[players.Length];
    }

    void Update()
    {
        //Trouve la cible
        NearestPlayerTarget();
        //avance vers la cible
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= actionRayon)
            GoToTarget();
    }

    //Cherche le joueur le plus proche et stock ce joueur dans la variable "target"
    void NearestPlayerTarget()
    {
        for (int i = 0; i < players.Length; i++)
        {
            distancePlayer[i] = Vector3.Distance(players[i].transform.position, transform.position);
        }

        nearest = Mathf.Min(distancePlayer);

        for (int i = 0; i < players.Length; i++)
        {
            if (nearest == distancePlayer[i])
            {
                target = players[i];
            }
        }
    }

    //Dirige l'ennemi vers le joueur ciblé "target"
    void GoToTarget()
    {
        direction = (target.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed * Time.deltaTime * 100);
    }
}