using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAccelerator : MonoBehaviour
{
    public Transform[] accelerateur;

    private EnnemiSourisCalcul calcul;

    void Start()
    {
        calcul = FindObjectOfType(typeof(EnnemiSourisCalcul)) as EnnemiSourisCalcul;
    }
    
    void Update()
    {
        if (calcul.firstPlayer > accelerateur[1].transform.position.x)
            gameObject.GetComponent<AudioSource>().pitch = 1.15f;
        else if (calcul.firstPlayer > accelerateur[0].transform.position.x)
            gameObject.GetComponent<AudioSource>().pitch = 1.05f;
        else
            gameObject.GetComponent<AudioSource>().pitch = 1f;

    }
}
