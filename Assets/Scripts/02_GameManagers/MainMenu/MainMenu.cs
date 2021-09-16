using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int NbPlayer;

    public Dropdown chooseNbPlayer;

    private VarNbPlayer nbPlayerScript;

    public GameObject[] panelJoueur;

    public Animator anim;

    public GameObject textInputInfo;
    public GameObject panelGame;

    public void Start()
    {
        PlayerPrefs.DeleteKey("numberPlayer");
        PlayerPrefs.DeleteKey("FirstPlayer");
    }

    public void Update()
    {
        nbPlayerScript = GameObject.FindObjectOfType<VarNbPlayer>();

        NbPlayer = chooseNbPlayer.value + 2;
        nbPlayerScript.varNbPlayer = PlayerPrefs.GetInt("numberPlayer");
        PlayerPrefs.SetInt("numberPlayer", NbPlayer);

        if (NbPlayer == 2)
        {
            panelJoueur[0].SetActive(true);
            panelJoueur[1].SetActive(false);
            panelJoueur[2].SetActive(false);
        }
        if (NbPlayer == 3)
        {
            panelJoueur[0].SetActive(false);
            panelJoueur[1].SetActive(true);
            panelJoueur[2].SetActive(false);
        }
        if (NbPlayer == 4)
        {
            panelJoueur[0].SetActive(false);
            panelJoueur[1].SetActive(false);
            panelJoueur[2].SetActive(true);
        }

        if (Input.anyKeyDown)
        {
            anim.SetBool("Title", true);
            panelGame.SetActive(true);
            Destroy(textInputInfo);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenuPlayManu()
    {
        anim.SetBool("PlayMenu", true);
    }

    public void PlayMenuMainMenu()
    {
        anim.SetBool("PlayMenu", false);
    }
}
