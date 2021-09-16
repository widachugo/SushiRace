using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeScript : MonoBehaviour
{
    public float timeBeforeActivated;
    public float timeStayActive;
    public GameObject child;

    public Renderer[] materials;
    private Material childMaterial;

    void Start()
    {
        //récupère les matériaux
        materials = GetComponentsInChildren<Renderer>();
        childMaterial = materials[1].material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Active le piège
            StartCoroutine("Activation");
        }
    }

    IEnumerator Activation()
    {
        Color defaultColor = GetComponent<Renderer>().material.color;
        Color defaultChildColor = childMaterial.color;

        GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        //Temps avant que le piège s'active
        yield return new WaitForSeconds(timeBeforeActivated);
        
        childMaterial.SetColor("_Color", Color.red);
        child.GetComponent<PiegeEffectScript>().active = true;

        //Temps où le piège est activé
        yield return new WaitForSeconds(timeStayActive);

        child.GetComponent<PiegeEffectScript>().active = false;
        GetComponent<Renderer>().material.SetColor("_Color", defaultColor);
        childMaterial.SetColor("_Color", defaultChildColor);
    }
}
