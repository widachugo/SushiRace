using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool boxTake;
    public bool boxFly;

    public float force;

    public float timeStun;

    private float iniSpeed = 5.0f;

    public Transform target;
    private Rigidbody rb;

    private Collider collide;

    private PlayerCharacterController controller;

    public GameObject boxDestroy;

    public void Start()
    {
        controller = GameObject.FindObjectOfType(typeof(PlayerCharacterController)) as PlayerCharacterController;
        rb = GetComponent<Rigidbody>();
        collide = GetComponent<BoxCollider>();
        boxTake = false;
        boxFly = false;
    }

    public void Update()
    {
        if (boxTake)
        {
            rb.useGravity = false;

            if (!boxFly)
            {
                transform.position = new Vector3(target.position.x, target.position.y + 2.2f, target.position.z);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                rb.useGravity = true;
            }

            if (target.name == "Player1(Clone)")
            {
                if (Input.GetButton("VerticalP1"))
                {
                    boxFly = true;
                    rb.velocity = new Vector3(force, 0, 0);
                    collide.isTrigger = true;
                }
            }
            if (target.name == "Player2(Clone)")
            {
                if (Input.GetButton("VerticalP2"))
                {
                    boxFly = true;
                    rb.velocity = new Vector3(force, 0, 0);
                    collide.isTrigger = true;
                }
            }
            if (target.name == "Player3(Clone)")
            {
                if (Input.GetButton("VerticalP3"))
                {
                    boxFly = true;
                    rb.velocity = new Vector3(force, 0, 0);
                    collide.isTrigger = true;
                }
            }
            if (target.name == "Player4(Clone)")
            {
                if (Input.GetButton("VerticalP4"))
                {
                    boxFly = true;
                    rb.velocity = new Vector3(force, 0, 0);
                    collide.isTrigger = true;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Prendre la caisse
        if (other.gameObject.tag == "Player" && !boxFly && !boxTake)
        {
            boxTake = true;
            target = other.gameObject.transform;
        }

        //Toucher un joueur
        if (boxFly && other.gameObject.tag == "Player" && other.gameObject.name != target.gameObject.name)
        {
            Debug.Log("box touche" + other.gameObject.name);

            StartCoroutine(Stun(other.gameObject));
        }

        //Destruction avec l'autre joueur
        if (other.gameObject.tag == "Player" && other.gameObject.name != target.gameObject.name)
        {
            StartCoroutine(destroyBox());
        }

        //Destruction avec le sol
        if (boxFly && other.gameObject.tag == "Ground")
        {
            StartCoroutine(destroyBox());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (target != null && other.gameObject.name == target.name)
        {
            boxTake = false;
        }
    }

    //Stunt
    IEnumerator Stun(GameObject player)
    {
        player.GetComponent<PlayerCharacterController>().speed = 1;

        yield return new WaitForSeconds(timeStun);

        player.GetComponent<PlayerCharacterController>().speed = iniSpeed;

        Destroy(gameObject);
    }

    //Destruction box
    IEnumerator destroyBox()
    {
        Instantiate(boxDestroy, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);

        yield break;
    }
}
