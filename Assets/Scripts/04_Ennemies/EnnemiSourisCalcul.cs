using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnnemiSourisCalcul : MonoBehaviour
{
    public GameObject[] playersPosition;
    public Vector3[] playerPos;
    public List<GameObject> Paul;

    private PlayerCharacterController[] players;
    private float[] distancePlayers;

    public Vector3 middlePoint;

    private float lastPlayer;
    public float firstPlayer;

    private SourieQuiNousPoursuitScript sourie;

    void Start()
    {
        players = FindObjectsOfType(typeof(PlayerCharacterController)) as PlayerCharacterController[];
        distancePlayers = new float[players.Length];

        sourie = FindObjectOfType(typeof(SourieQuiNousPoursuitScript)) as SourieQuiNousPoursuitScript;
    }

    private void Update()
    {
        //Point médian
        playersPosition = GameObject.FindGameObjectsWithTag("Player");
        playerPos = new Vector3[players.Length];
        Paul = new List<GameObject>(playersPosition);

        for (int i = 0; i < players.Length; i++)
        {
            if (playersPosition.Length < players.Length)
            {
                    Paul.Add(gameObject);
            }

            playerPos[i] = Paul.ToArray()[i].transform.position;
        }

        middlePoint = SommePos() / (players.Length);

        transform.position = middlePoint;

        //Premier et dernier joueur
        for (int i = 0; i < players.Length; i++)
        {
            distancePlayers[i] = Mathf.Abs(-players[i].transform.position.x);
        }

        lastPlayer = Mathf.Min(distancePlayers);
        firstPlayer = Mathf.Max(distancePlayers);
    }

    Vector3 SommePos()
    {
        Vector3 calculatePos = Vector3.zero;

        for (int i = 0; i < playerPos.Length; i++)
        {
            calculatePos += playerPos[i];
        }

        return calculatePos;
    }
}
