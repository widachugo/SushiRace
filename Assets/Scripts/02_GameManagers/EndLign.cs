using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLign : MonoBehaviour
{
    private PlayerCharacterController[] controller;

    private VarNbPlayer nbPlayerScript;

    public int firstPlayer;

    public void Start()
    {
        nbPlayerScript = FindObjectOfType<VarNbPlayer>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerCharacterController>().ID == 1)
            {
                firstPlayer = 1;
            }
            if (other.gameObject.GetComponent<PlayerCharacterController>().ID == 2)
            {
                firstPlayer = 2;
            }
            if (other.gameObject.GetComponent<PlayerCharacterController>().ID == 3)
            {
                firstPlayer = 3;
            }
            if (other.gameObject.GetComponent<PlayerCharacterController>().ID == 4)
            {
                firstPlayer = 4;
            }

            PlayerPrefs.SetInt("FirstPlayer", firstPlayer);
            nbPlayerScript.firstPlayer = PlayerPrefs.GetInt("FirstPlayer");

            SceneManager.LoadScene("EndMenu");
        }
    }

    public void Update()
    {
        controller = GameObject.FindObjectsOfType(typeof(PlayerCharacterController)) as PlayerCharacterController[];
        System.Array.Reverse(controller);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Proto");
    }

    public void MainMenuReturn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
