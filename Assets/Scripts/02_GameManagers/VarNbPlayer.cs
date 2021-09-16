using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarNbPlayer : MonoBehaviour
{
    public int varNbPlayer;

    public int firstPlayer;

    public void Update()
    {
        if (PlayerPrefs.HasKey("FirstPlayer"))
        {
            firstPlayer = PlayerPrefs.GetInt("FirstPlayer");
        }

        DontDestroyOnLoad(this);
    }
}
