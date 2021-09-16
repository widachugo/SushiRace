using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public int firstPlayer;

    private VarNbPlayer nbPlayerScript;

    public GameObject[] firstObjectChild;
    public GameObject[] last2Playeurs;
    public GameObject[] last3Playeurs;
    public GameObject[] last4Playeurs;

    public void Start()
    {
        nbPlayerScript = FindObjectOfType<VarNbPlayer>();
    }

    public void Update()
    {
        firstPlayer = nbPlayerScript.firstPlayer;

            for (int i = 0; i < firstObjectChild.Length; i++)
            {
                if (i == (firstPlayer - 1))
                {
                    firstObjectChild[i].SetActive(true);
                }

                if (nbPlayerScript.varNbPlayer == 2)
                {
                    if (i != (firstPlayer - 1))
                    {
                        last2Playeurs[i].SetActive(true);
                    }
                }

                if (nbPlayerScript.varNbPlayer == 3)
                {
                    if (i != (firstPlayer - 1))
                    {
                        last3Playeurs[i].SetActive(true);
                    }
                }

                if (nbPlayerScript.varNbPlayer == 4)
                {
                    if (i != (firstPlayer - 1))
                    {
                        last4Playeurs[i].SetActive(true);
                    }
                }
            }
        }

    public void Restart()
    {
        PlayerPrefs.DeleteKey("FirstPlayer");
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
