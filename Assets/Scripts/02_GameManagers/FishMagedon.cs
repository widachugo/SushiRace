using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMagedon : MonoBehaviour
{
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InstantDeath")
        {
            //rb.isKinematic = false;
            //rb.useGravity = true;
        }
    }
}
