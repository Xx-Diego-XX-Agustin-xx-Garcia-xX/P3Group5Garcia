using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    public float mineSpeed = 50;
    private PlayerHealth playerHealth;
    private PlayerController playerController;
    private GameManager gameManager;
    public bool hasAlreadyDamaged;

    // Start is called before the first frame update
    void Start()
    {
       playerHealth = GameObject.Find("ZodiacAlphaA23").GetComponent<PlayerHealth>();
       playerController = GameObject.Find("ZodiacAlphaA23").GetComponent<PlayerController>();
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.sagittariusDash == true)
        {
            transform.Translate(Vector3.forward * (mineSpeed * 2) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * mineSpeed * Time.deltaTime);
        }
        

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerMissile"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(10);
        }
        if (collision.gameObject.CompareTag("Player") && !hasAlreadyDamaged)
        {
            playerHealth.DamagePlayer(20);
            hasAlreadyDamaged = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
