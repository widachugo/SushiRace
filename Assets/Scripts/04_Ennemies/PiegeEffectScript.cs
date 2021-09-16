using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeEffectScript : MonoBehaviour
{
    public float waitClearTime;
    public bool active;
    
    private GameObject player;
    public float playerSpeedDefault;

    private void OnTriggerEnter(Collider other)
    {
        //si le piège est activé
        if (active)
        {
            //Touche un joueur et lance l'effet du piège
            if (other.tag == "Player")
            {
                player = other.gameObject;
                StartCoroutine("WaitClear");
            }
        }
    }

    IEnumerator WaitClear()
    {
        yield return new WaitForSeconds(0.5f);
        
        if (player.GetComponent<PlayerCharacterController>().speed > 0.35f*playerSpeedDefault)
        {
            Debug.Log("Avant" + player.GetComponent<PlayerCharacterController>().speed);
            player.GetComponent<PlayerCharacterController>().speed -= 0.1f * player.GetComponent<PlayerCharacterController>().speed;
            Debug.Log("Après" + player.GetComponent<PlayerCharacterController>().speed);
            StartCoroutine("WaitClear");
        }
        else
        {
            player.GetComponent<PlayerCharacterController>().speed = playerSpeedDefault;
        }
    }
}