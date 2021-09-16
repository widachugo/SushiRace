using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInput : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    public float delay = 2.0f;

    public void Start()
    {
        object1.SetActive(true);
        object2.SetActive(false);

        StartCoroutine("InputSwitch");
    }

    IEnumerator InputSwitch()
    {
        yield return new WaitForSeconds(delay);
        object1.SetActive(false);
        object2.SetActive(true);
        yield return new WaitForSeconds(delay);
        object1.SetActive(true);
        object2.SetActive(false);
        StartCoroutine("InputSwitch");
    }
}
