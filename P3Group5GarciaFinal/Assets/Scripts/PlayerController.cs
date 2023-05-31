using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] ariesWrath;
    private float horizontalInput;
    private float verticalInput;
    public float speed = 50;
    private float nextShot = 0.15f;
    private float nextHeal = 0.15f;
    private float nextAriesWrath = 0.15f;
    public GameObject playerProjectile;
    private float xRange = 50;
    public AudioClip shootingSound;
    private AudioSource playerAudio;
    private PlayerHealth playerHealth;
    public float fireDelay = 0.25f;
    public float healDelay = 30f;
    public float ariesWrathDelay = 120f;
    public ParticleSystem healParticle;
    public ParticleSystem ariesWrathParticle;
    public ParticleSystem sagittariusDashParticle;
    public bool virgosBlessingUsed;
    public bool ariesWrathUsed;
    private GameManager gameManager;
    private float virgosBlessingScreenTime;
    private float ariesWrathScreenTime;
    public bool sagittariusDash;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player left or right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        // Moves the player up and down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        // Bounds the player horizontally
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Bounds the player vertically
        if (transform.position.y > 36)
        {
            transform.position = new Vector3(transform.position.x, 36, transform.position.z);
        }
        if (transform.position.y < -18)
        {
            transform.position = new Vector3(transform.position.x, -18, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextShot)
        {
            Vector3 offset = new Vector3(0, 0, 4f);
            Instantiate(playerProjectile, transform.position + offset, playerProjectile.transform.rotation);
            nextShot = Time.time + fireDelay;
            playerAudio.PlayOneShot(shootingSound, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextHeal && virgosBlessingUsed == false)
        {
            virgosBlessingScreenTime = 5.0f;
            playerHealth.HealPlayer(50);
            nextHeal = Time.time + healDelay;
            healParticle.Play();
            virgosBlessingUsed = true;
            gameManager.virgosBlessingScreen.SetActive(true);
        }
        else if (Time.time > nextHeal)
        {
            healParticle.Stop();
            virgosBlessingUsed = false;
        }

        virgosBlessingScreenTime -= Time.deltaTime;

        if (virgosBlessingScreenTime <= 0)
        {
            gameManager.virgosBlessingScreen.SetActive(false);
        }

        void AriesWrath()
        {
            for (int i = 0; i < 1000; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-150, 150), Random.Range(-100, 100), 0);
                int AriesWrathIndex = Random.Range(0, ariesWrath.Length);
                Instantiate(ariesWrath[AriesWrathIndex], spawnPos, ariesWrath[AriesWrathIndex].transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && Time.time > nextAriesWrath && ariesWrathUsed == false)
        {
            AriesWrath();
            ariesWrathUsed = true;
            ariesWrathScreenTime = 5.0f;
            nextAriesWrath = Time.time + ariesWrathDelay;
            ariesWrathParticle.Play();
            gameManager.ariesWrathScreen.SetActive(true);
        }
        else if (Time.time > nextAriesWrath)
        {
            ariesWrathUsed = false;
            ariesWrathParticle.Stop();
        }

        ariesWrathScreenTime -= Time.deltaTime;

        if (ariesWrathScreenTime <= 0)
        {
            gameManager.ariesWrathScreen.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sagittariusDash = true;
            sagittariusDashParticle.Play();
            gameManager.sagittariusDashScreen.SetActive(true);
        }
        else
        {
            sagittariusDash = false;
            gameManager.sagittariusDashScreen.SetActive(false);
            sagittariusDashParticle.Stop();
        } 
    }
}
