using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Timer : MonoBehaviour
{
    public Text textTimer;

    public int timeStart = 3;
    private float timer;

    public bool gameStart = false;

    public GameObject startWalls;

    //Sauter avant de jouer:
    private List<PlayerCharacterController> listPlayer;
    private bool canStart = false;
    public int countPlayer;
    private CameraTeleporterScript camScript;

    private bool miseEnPlace = true;
    private bool enleveMoiLaCoche;

    void Start()
    {
        timer = 0.0f;
        startWalls.SetActive(true);

        listPlayer = new List<PlayerCharacterController>(FindObjectsOfType(typeof(PlayerCharacterController)) as PlayerCharacterController[]);
        camScript = FindObjectOfType(typeof(CameraTeleporterScript)) as CameraTeleporterScript;
    }

    void Update()
    {
        if (canStart)
        {
            textTimer.gameObject.SetActive(true);

            if (!gameStart)
            {
                textTimer.text = timeStart.ToString();

                timer += Time.deltaTime;

                if (timer >= 1)
                {
                    timeStart--;
                    timer = 0.0f;
                }

                if (timeStart == 0)
                {
                    StartCoroutine("gameStarted");
                    gameStart = true;
                }
            }
        }

        //pour check si le joueur à sauter avant la course
        if (countPlayer < listPlayer.Count)
        {
            foreach (PlayerCharacterController player in listPlayer)
            {
                if (player.hasJump & player.hasCount == false)
                {
                    player.hasCount = true;
                    countPlayer++;
                }
            }
        }
        else if (miseEnPlace)
        {
            canStart = true;

            camScript.miseEnPlace = true;
            Debug.Log("J'active MIS");

            miseEnPlace = false;
            enleveMoiLaCoche = true;
        }

        if (enleveMoiLaCoche)
        {
            foreach (PlayerCharacterController player in listPlayer)
                player.coche.SetActive(false);
        }
    }

    IEnumerator gameStarted()
    {
        textTimer.text = "GO !";
        startWalls.SetActive(false);

        Debug.Log("Je désactive MIS");
        camScript.miseEnPlace = false;
        camScript.active = true;

        yield return new WaitForSeconds(1.0f);
        textTimer.text = "";
    }
}
