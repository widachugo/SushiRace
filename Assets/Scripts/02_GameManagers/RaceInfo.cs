using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceInfo : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public Image avancement;

    public PlayerCharacterController[] players;
    public SourieQuiNousPoursuitScript poisson;
    private float[] distancePlayers;
    private float[] distancePlayersSprite;

    public GameObject[] spriteSushi;
    public GameObject spritePoisson;

    public void Start()
    {
        players = FindObjectsOfType(typeof(PlayerCharacterController)) as PlayerCharacterController[];
        poisson = FindObjectOfType<SourieQuiNousPoursuitScript>();
        System.Array.Reverse(players);
    }

    public void Update()
    {
        distancePlayers = new float[players.Length];
        distancePlayersSprite = new float[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            distancePlayers[i] = Mathf.Abs(players[i].transform.position.x);

            spriteSushi[i].SetActive(true);

            if (players[i].ID == i + 1)
            {
                float distPoints = Vector3.Distance(start.position, end.position);
                distancePlayersSprite[i] = Vector3.Distance(start.position, players[i].transform.position);

                spriteSushi[i].transform.position = new Vector3(Mathf.Lerp(0, 1770, distancePlayersSprite[i] / distPoints), spriteSushi[i].transform.position.y, spriteSushi[i].transform.position.z);
            }
        }

        float firstPlayer = Mathf.Max(distancePlayers);

        float distFirstPlayer = Vector3.Distance(start.position, new Vector3(firstPlayer, 0, 0));

        avancement.fillAmount = Mathf.Lerp(start.position.x / 10, distFirstPlayer / 10, 0.0095f);

        //Distance Poisson
        float distPointsB = Vector3.Distance(start.position, end.position);
        float distPoisson = Vector3.Distance(start.position, poisson.transform.position);

        spritePoisson.transform.position = new Vector3(Mathf.Lerp(start.position.x, end.position.x, distPoisson / distPointsB), spritePoisson.transform.position.y, spritePoisson.transform.position.z); ;
    }
}
