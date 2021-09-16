using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtScript : MonoBehaviour
{
    public float offset;

    private EnnemiSourisCalcul ennemiSourisCalcul;
    private CameraTeleporterScript cameraScript;

    void Start()
    {
        ennemiSourisCalcul = FindObjectOfType(typeof(EnnemiSourisCalcul)) as EnnemiSourisCalcul;
        cameraScript = FindObjectOfType(typeof(CameraTeleporterScript)) as CameraTeleporterScript;
    }
    
    void Update()
    {
        if (cameraScript.active)
        {
            Vector3 position = Vector3.Lerp(transform.position, ennemiSourisCalcul.transform.position, 0.05f);
            position = new Vector3(position.x + cameraScript.offset + offset, Mathf.Lerp(transform.position.y, ennemiSourisCalcul.middlePoint.y, 0.05f), position.z);

            transform.position = position;
        }
    }
}
