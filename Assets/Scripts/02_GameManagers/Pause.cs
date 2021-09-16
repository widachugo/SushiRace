using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton7))
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Reprendre()
    {
        Time.timeScale = 1.0f;
        pauseCanvas.SetActive(false);
    }
}
