using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointScript : MonoBehaviour
{
    private PlayerCharacterController[] players;
    private SourieQuiNousPoursuitScript souris;
    private float[] distancePlayers;
    private float zAxi = 0;

    public int indexWayPoints = 0;
    public GameObject[] wayPoints;
    public Transform wayPointTarget;
    //private bool reset = true;

    //public bool canSpawn = false;

    void Start()
    {
        transform.position = Vector3.zero;
        souris = FindObjectOfType(typeof(SourieQuiNousPoursuitScript)) as SourieQuiNousPoursuitScript;
    }

    void Update()
    {
        //Waypoints
        wayPointTarget = wayPoints[indexWayPoints].transform;

        if (transform.position.x >= wayPointTarget.position.x && indexWayPoints < wayPoints.Length - 1)
        {
            indexWayPoints++;
        }

        if (indexWayPoints > 0)
        {
            zAxi = wayPoints[indexWayPoints].transform.position.z;
        }
        else
        {
            zAxi = wayPoints[0].transform.position.z;
        }

        //Premier et dernier joueur

        players = FindObjectsOfType(typeof(PlayerCharacterController)) as PlayerCharacterController[];
        distancePlayers = new float[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            distancePlayers[i] = Mathf.Abs(players[i].transform.position.x);
        }

        float firstPlayer = Mathf.Max(distancePlayers);

        //position
        if (firstPlayer > transform.position.x - 20)
            transform.position = new Vector3(Mathf.Clamp(firstPlayer + 20, transform.position.x, wayPoints[wayPoints.Length - 1].transform.position.x), 40, zAxi);
    }
}
