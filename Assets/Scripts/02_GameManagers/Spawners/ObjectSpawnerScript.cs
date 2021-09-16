using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject[] objectToSpawn;

    private List<Transform> spawnPoints;
    private int spawnpoint;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>().ToList<Transform>();
        spawnPoints.Remove(transform);

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnpoint = i;
            SpawnOpponent();
        }
    }

    void SpawnOpponent()
    {
        int objectNb = 0;

            float prob = Random.Range(0, 100);
            if (prob < 90)
            {
                GameObject Opponent = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], spawnPoints[spawnpoint].position, spawnPoints[spawnpoint].rotation);
                objectNb = objectNb + 1;
            }
    }
}
