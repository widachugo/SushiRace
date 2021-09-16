using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMainMenuPlayer : MonoBehaviour
{
    public int speed;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
