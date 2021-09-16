using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public int nbPlayer;

    public Transform[] spawnPlayer;

    public GameObject[] player;
    public GameObject RespawnPoint;

    //coroutine
    private float iniSpeedP1;
    private float iniSpeedP2;
    private float iniSpeedP3;
    private float iniSpeedP4;

    private float timerP1;
    private float timerP2;
    private float timerP3;
    private float timerP4;

    private bool lauchRespawnP1;
    private bool lauchRespawnP2;
    private bool lauchRespawnP3;
    private bool lauchRespawnP4;

    private GameObject playerRespawn1;
    private GameObject playerRespawn2;
    private GameObject playerRespawn3;
    private GameObject playerRespawn4;

    private bool resetTimerP1 = true;
    private bool resetTimerP2 = true;
    private bool resetTimerP3 = true;
    private bool resetTimerP4 = true;


    private VarNbPlayer varNbPlayerScript;

    private PlayerCharacterController[] players;
    private RespawnPointScript respawn;
    private float[] distancePlayers;

    public Material matPlayer1;
    public Material matPlayer2;
    public Material matPlayer3;
    public Material matPlayer4;

    public void Start()
    {
        Time.timeScale = 1.0f;

        varNbPlayerScript = GameObject.FindObjectOfType<VarNbPlayer>();

        nbPlayer = varNbPlayerScript.varNbPlayer;

        Spawn();
    }

    public void Spawn()
    {
        if (nbPlayer == 2)
        {
            Instantiate(player[0], spawnPlayer[0].position, spawnPlayer[0].rotation);
            Instantiate(player[1], spawnPlayer[1].position, spawnPlayer[1].rotation);
        }

        if (nbPlayer == 3)
        {
            Instantiate(player[0], spawnPlayer[0].position, spawnPlayer[0].rotation);
            Instantiate(player[1], spawnPlayer[1].position, spawnPlayer[1].rotation);
            Instantiate(player[2], spawnPlayer[2].position, spawnPlayer[2].rotation);
        }

        if (nbPlayer == 4)
        {
            Instantiate(player[0], spawnPlayer[0].position, spawnPlayer[0].rotation);
            Instantiate(player[1], spawnPlayer[1].position, spawnPlayer[1].rotation);
            Instantiate(player[2], spawnPlayer[2].position, spawnPlayer[2].rotation);
            Instantiate(player[3], spawnPlayer[3].position, spawnPlayer[3].rotation);
        }

        matPlayer1.DisableKeyword("_EMISSION");
        matPlayer1.color = Color.white;
        matPlayer2.DisableKeyword("_EMISSION");
        matPlayer2.color = Color.white;
        matPlayer3.DisableKeyword("_EMISSION");
        matPlayer3.color = Color.white;
        matPlayer4.DisableKeyword("_EMISSION");
        matPlayer4.color = Color.white;
    }

    private void Update()
    {
        if (lauchRespawnP1)
        {

            if (resetTimerP1)
            {
                resetTimerP1 = false;
                timerP1 = 2;
            }

            timerP1 -= 1 * Time.deltaTime;
            if (timerP1 <= 0)
            {
                playerRespawn1.transform.position = RespawnPoint.transform.position;
                playerRespawn1.GetComponent<PlayerCharacterController>().speed = iniSpeedP1;

                playerRespawn1.SetActive(true);
                playerRespawn1.GetComponent<PlayerCharacterController>().CallStun();
                lauchRespawnP1 = false;
                resetTimerP1 = true;

                matPlayer1.DisableKeyword("_EMISSION");
                matPlayer1.color = Color.white;
                playerRespawn1.GetComponent<PlayerCharacterController>().Curhealth = playerRespawn1.GetComponent<PlayerCharacterController>().Maxhealth;
            }
        }

        if (lauchRespawnP2)
        {
            if (resetTimerP2)
            {
                resetTimerP2 = false;
                timerP2 = 2;
            }

            timerP2 -= 1 * Time.deltaTime;
            if (timerP2 <= 0)
            {
                playerRespawn2.transform.position = RespawnPoint.transform.position;
                playerRespawn2.GetComponent<PlayerCharacterController>().speed = iniSpeedP2;

                playerRespawn2.SetActive(true);
                playerRespawn2.GetComponent<PlayerCharacterController>().CallStun();
                lauchRespawnP2 = false;
                resetTimerP2 = true;

                matPlayer2.DisableKeyword("_EMISSION");
                matPlayer2.color = Color.white;
                playerRespawn2.GetComponent<PlayerCharacterController>().Curhealth = playerRespawn2.GetComponent<PlayerCharacterController>().Maxhealth;
            }
        }

        if (lauchRespawnP3)
        {
            if (resetTimerP3)
            {
                resetTimerP3 = false;
                timerP3 = 2;
            }

            timerP3 -= 1 * Time.deltaTime;
            if (timerP3 <= 0)
            {
                playerRespawn3.transform.position = RespawnPoint.transform.position;
                playerRespawn3.GetComponent<PlayerCharacterController>().speed = iniSpeedP3;

                playerRespawn3.SetActive(true);
                playerRespawn3.GetComponent<PlayerCharacterController>().CallStun();
                lauchRespawnP3 = false;
                resetTimerP3 = true;

                matPlayer3.DisableKeyword("_EMISSION");
                matPlayer3.color = Color.white;
                playerRespawn3.GetComponent<PlayerCharacterController>().Curhealth = playerRespawn3.GetComponent<PlayerCharacterController>().Maxhealth;
            }
        }

        if (lauchRespawnP4)
        {
            if (resetTimerP4)
            {
                resetTimerP4 = false;
                timerP4 = 2;
            }

            timerP4 -= 1 * Time.deltaTime;
            if (timerP4 <= 0)
            {
                playerRespawn4.transform.position = RespawnPoint.transform.position;
                playerRespawn4.GetComponent<PlayerCharacterController>().speed = iniSpeedP4;

                playerRespawn4.SetActive(true);
                playerRespawn4.GetComponent<PlayerCharacterController>().CallStun();
                lauchRespawnP4 = false;
                resetTimerP4 = true;

                matPlayer4.DisableKeyword("_EMISSION");
                matPlayer4.color = Color.white;
                playerRespawn4.GetComponent<PlayerCharacterController>().Curhealth = playerRespawn4.GetComponent<PlayerCharacterController>().Maxhealth;
            }
        }
    }

    public void Respawn(GameObject player)
    {
        if (player.name == "Player1(Clone)")
        {
            lauchRespawnP1 = true;
            playerRespawn1 = player;
            iniSpeedP1 = player.GetComponent<PlayerCharacterController>().iniSpeed;
        }
        if (player.name == "Player2(Clone)")
        {
            lauchRespawnP2 = true;
            playerRespawn2 = player;
            iniSpeedP2 = player.GetComponent<PlayerCharacterController>().iniSpeed;
        }
        if (player.name == "Player3(Clone)")
        {
            lauchRespawnP3 = true;
            playerRespawn3 = player;
            iniSpeedP3 = player.GetComponent<PlayerCharacterController>().iniSpeed;
        }
        if (player.name == "Player4(Clone)")
        {
            lauchRespawnP4 = true;
            playerRespawn4 = player;
            iniSpeedP4 = player.GetComponent<PlayerCharacterController>().iniSpeed;
        }

        player.SetActive(false);
    }
}
