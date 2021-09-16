using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleporterScript : MonoBehaviour
{
    private EnnemiSourisCalcul ennemiSourisCalcul;
    private Vector3 basePosition;
    public float offset = 1;
    public GameObject LookAt;

    public bool miseEnPlace;
    public Transform spawnPointStart;
    public bool active;

    private Vector3 firstPosition;
    private Quaternion firstRotation;
    private float countMiseEnPlace;

    void Start()
    {
        ennemiSourisCalcul = FindObjectOfType(typeof(EnnemiSourisCalcul)) as EnnemiSourisCalcul;
        basePosition = transform.position;

        firstPosition = transform.position;
        firstRotation = transform.rotation;
    }

    void Update()
    {
        if (miseEnPlace)
        {
            countMiseEnPlace += Time.deltaTime/2;
            transform.position = Vector3.Lerp(firstPosition, spawnPointStart.position, Mathf.Pow(countMiseEnPlace,3f));
            transform.rotation = Quaternion.Lerp(firstRotation, spawnPointStart.rotation, countMiseEnPlace);
            
        }

        if (active)
        {
            //mouvement camera
            Vector3 position = Vector3.Lerp(transform.position, ennemiSourisCalcul.transform.position, 0.05f);
            float supPos = position.x + offset;
            position = new Vector3(supPos, basePosition.y, Mathf.Lerp(transform.position.z, LookAt.transform.position.z + basePosition.z, 0.35f));
            transform.position = position;

            transform.LookAt(LookAt.transform.position);
        }
    }
}
