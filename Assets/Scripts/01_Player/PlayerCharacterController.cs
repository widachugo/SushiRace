using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    //TypePlayer
    public enum PlayerType { Player1, Player2, Player3, Player4 };
    public PlayerType playerType;

    //Var Vie player
    public int Curhealth;
    public int Maxhealth;

    //ID Player
    public int ID;

    //Var Vitesse player
    public float speed;
    public float speedJump;
    public float gravity;

    private bool retablissement;

    //Var Mouvements Vecteurs
    private Vector3 move = Vector3.zero;

    //CharacterController
    private CharacterController controller;
    public bool moving;

    //Dammage
    private float tickDammage;

    //Acces script
    private EndLign end;

    //Score
    public int score;

    //Dernière position
    public Vector3 lastPos;

    //Calcul vitesse
    private float t = 0.0f;
    public float vitesse = 0.0f;

    //Objet pris
    public bool objectTake = false;

    //inertie
    public float inertieX;
    public float inertieZ;
    private float inputHorizontal = 0;
    private float inputZAxeP = 0;

    //respawn
    private SpawnPlayer spawnPlayer;
    public float iniSpeed;

    //Particules
    public GameObject runParticle;
    public GameObject jumpParticle;
    public GameObject fallJumpParticle;
    public GameObject waterParticle;
    public GameObject oilParticle;
    public GameObject eatParticle;
    public GameObject stunParticle;
    public GameObject bonusParticle;

    //Detection sol
    public bool grounded;
    public GameObject rayDetect;

    //Sons
    public AudioClip[] jumpSound;
    public AudioClip waterSound;

    //Animation
    private Animator anim;

    //Renderer
    public Material mat;

    private EnnemiSourisCalcul ennemiSourisCalcul;

    private bool stunActive = false;
    public bool bonusActive = false;

    //Avant la course
    public bool hasJump;
    public bool hasCount;
    public GameObject coche;
    private bool cocheAction;
    private bool step1 = false;

    void Start()
    {
        //Initialisation vie
        Curhealth = Maxhealth;

        controller = GetComponent<CharacterController>();

        end = GameObject.FindObjectOfType(typeof(EndLign)) as EndLign;

        spawnPlayer = FindObjectOfType(typeof(SpawnPlayer)) as SpawnPlayer;

        ennemiSourisCalcul = FindObjectOfType<EnnemiSourisCalcul>();

        iniSpeed = speed;

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        #region Mouvements Players

        if (gameObject.name == "Player" + ID + "(Clone)")
        {
            //inertie Horizontal
            if (Input.GetAxis("HorizontalP" + ID) > 0)
                inputHorizontal = Mathf.Clamp(inputHorizontal + 0.1f, 0, 1);

            if (Input.GetAxis("HorizontalP" + ID) < 0)
                inputHorizontal = Mathf.Clamp(inputHorizontal - 0.1f, -1, 0);

            if (Input.GetAxis("HorizontalP" + ID) == 0)
            {
                if (inputHorizontal > 0)
                {
                    inputHorizontal = Mathf.Clamp(inputHorizontal - (inertieX) * Mathf.Abs(inputHorizontal) * 0.01f, 0, 1);
                    if (inputHorizontal <= 0.05)
                        inputHorizontal = 0;
                }

                if (inputHorizontal < 0)
                {
                    inputHorizontal = Mathf.Clamp(inputHorizontal + (inertieX) * Mathf.Abs(inputHorizontal) * 0.01f, -1, 0);
                    if (inputHorizontal >= -0.05)
                        inputHorizontal = 0;
                }
            }

            inputHorizontal = inputHorizontal * Time.deltaTime * 60f;

            //inertie ZAxeP
            if (Input.GetAxis("ZAxeP" + ID) > 0)
                inputZAxeP = Mathf.Clamp(inputZAxeP + 0.1f, 0, 1);

            if (Input.GetAxis("ZAxeP" + ID) < 0)
                inputZAxeP = Mathf.Clamp(inputZAxeP - 0.1f, -1, 0);

            if (Input.GetAxis("ZAxeP" + ID) == 0)
            {
                if (inputZAxeP > 0)
                {
                    inputZAxeP = Mathf.Clamp(inputZAxeP - (inertieZ) * Mathf.Abs(inputZAxeP) * 0.01f, 0, 1);
                    if (inputZAxeP <= 0.05)
                        inputZAxeP = 0;
                }

                if (inputZAxeP < 0)
                {
                    inputZAxeP = Mathf.Clamp(inputZAxeP + (inertieZ) * Mathf.Abs(inputZAxeP) * 0.01f, -1, 0);
                    if (inputZAxeP >= -0.05)
                        inputZAxeP = 0;
                }
            }

            inputZAxeP = inputZAxeP * Time.deltaTime * 60f;

            //controles
            if (controller.isGrounded)
            {
                move = new Vector3(inputHorizontal * speed, 0, inputZAxeP * speed);
                move = transform.TransformDirection(move);
                move = move * speed;

                if (moving)
                {
                    runParticle.SetActive(true);
                    anim.SetBool("Run", true);
                }
                else
                {
                    runParticle.SetActive(false);
                    anim.SetBool("Run", false);
                }

                if (Input.GetButton("VerticalP" + ID))
                {

                    //Avant la course, le premier jump déclenche un feedback
                    if (hasJump == false)
                    {
                        hasJump = true;
                        cocheAction = true;
                    }

                    Instantiate(jumpParticle, gameObject.transform.position, gameObject.transform.rotation);

                    anim.SetBool("Jump", true);

                    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.clip = jumpSound[Random.Range(0, jumpSound.Length)];
                    audioSource.volume = 0.15f;
                    audioSource.pitch = 1.0f;
                    audioSource.Play();
                    Destroy(audioSource, 5.0f);

                    move = new Vector3(0, Mathf.Lerp(gameObject.transform.position.y, speedJump, 0.1f) * Time.deltaTime * 61, 0);
                }
                else
                {
                    anim.SetBool("Jump", false);
                }
            }

            if (controller.isGrounded == false)
            {
                move = new Vector3(inputHorizontal * speed / 1.4f, (move.y - (gravity * Time.deltaTime)) / speed, inputZAxeP * speed / 1.4f);
                move = transform.TransformDirection(move);
                move = move * speed;

                anim.SetBool("Fall", true);
            }
            else
            {
                anim.SetBool("Fall", false);
            }
        }

        controller.Move(move * Time.deltaTime);

        if (this.transform.position != lastPos)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            t += Time.deltaTime;
            if (t > 0.1f)
            {
                this.vitesse += t;
                t = 0.0f;
            }
        }
        else
        {
            vitesse = 0.0f;
        }

        #endregion

        RaycastHit hit;

        Debug.DrawRay(rayDetect.transform.position, Vector3.down * 0.2f, Color.red);

        if (Physics.Raycast(rayDetect.transform.position, Vector3.down, out hit, 0.2f))
        {
            if (hit.collider.tag == "Ground")
            {
                grounded = false;
                anim.SetBool("Fall", true);
            }
            else
            {
                grounded = true;
                anim.SetBool("Fall", false);
            }
        }

        if (retablissement)
        {
            if (speed >= iniSpeed + 0.1f && speed <= iniSpeed - 0.1f)
            {
                speed = Mathf.Lerp(speed, iniSpeed, iniSpeed * Time.time / 10 + speed) * Time.deltaTime;
            }
            else
            {
                speed = iniSpeed;
                retablissement = false;
                stunParticle.SetActive(false);
                stunActive = false;
            }
        }

        if (!bonusActive && !stunActive && transform.position.x < FindObjectOfType<EnnemiSourisCalcul>().firstPlayer)
        {
            speed = iniSpeed + 0.2f;
        }
        else if (!stunActive && !bonusActive)
        {
            speed = iniSpeed;
        }

        if (cocheAction)
        {
            coche.SetActive(true);
            Vector3 max = new Vector3(10, 10, 10);

            if (coche.transform.localScale.x + 0.1f >= max.x)
                step1 = true;

            if (step1 ==false)
                coche.transform.localScale = Vector3.Lerp(coche.transform.localScale, max, 0.2f);
            else
                coche.transform.localScale = Vector3.Lerp(coche.transform.localScale, Vector3.one*2, 0.1f);

            if (coche.transform.localScale.x - 0.1f <= 2)
                cocheAction = false;
        }
    }

    public void LateUpdate()
    {
        lastPos = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Mort Instant
        if (other.gameObject.tag == "InstantDeath")
        {
            //respawn function dans le gameManager
            Death();
        }

        if (other.gameObject.tag == "Water")
        {
            Instantiate(waterParticle, gameObject.transform.position, gameObject.transform.rotation);

            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = waterSound;
            audioSource.volume = 0.2f;
            audioSource.Play();
            Destroy(audioSource, 1.0f);
        }

        if (other.gameObject.tag == "Oil")
        {
            Instantiate(oilParticle, gameObject.transform.position, gameObject.transform.rotation);
            StartCoroutine(TakeDammage(0.1f));
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Ajouter le tag "DeathZone" aux zones pour tuer
        if (other.gameObject.tag == "Dammage")
        {
            tickDammage += Time.deltaTime;

            if (tickDammage >= 0.5f)
            {
                Curhealth--;
                StartCoroutine(TakeDammage(0.1f));
                tickDammage = 0.0f;
            }
        }
    }

    //Tick Dammage Coroutine
    IEnumerator TakeDammage(float tick)
    {
        if (Curhealth >= 1)
        {
            mat.EnableKeyword("_EMISSION");
            mat.color = Color.red;
            yield return new WaitForSeconds(tick);
            mat.DisableKeyword("_EMISSION");
            mat.color = Color.white;
            yield return new WaitForSeconds(tick);
            mat.EnableKeyword("_EMISSION");
            mat.color = Color.red;
            yield return new WaitForSeconds(tick);
            mat.DisableKeyword("_EMISSION");
            mat.color = Color.white;
            yield return new WaitForSeconds(tick);
            mat.EnableKeyword("_EMISSION");
            mat.color = Color.red;
            yield return new WaitForSeconds(tick);
            mat.DisableKeyword("_EMISSION");
            mat.color = Color.white;
        }
        else
        {
            Death();
        }
    }

    //Mort
    public void Death()
    {
        DeathSounds deathSounds = FindObjectOfType<DeathSounds>();
        deathSounds.DeathSong();

        Instantiate(eatParticle, gameObject.transform.position, gameObject.transform.rotation);
        spawnPlayer.Respawn(gameObject);
    }

    //Score 
    public void AddScore()
    {
        score++;
    }

    public void CallStun()
    {
        StartCoroutine(Stun());
    }

    //Stunt
    IEnumerator Stun()
    {
        stunActive = true;

        speed = 1;

        stunParticle.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        retablissement = true;
    }
}
