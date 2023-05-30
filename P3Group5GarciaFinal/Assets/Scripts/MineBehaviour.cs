using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    public float mineSpeed = 50;
    private PlayerHealth playerHealth;
    public int life = 1;
    public bool hasAlreadyDamaged;

    // Start is called before the first frame update
    void Start()
    {
       playerHealth = GameObject.Find("ZodiacAlphaA23").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * mineSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerMissile"))
        {
            life--;
        }
        if (collision.gameObject.CompareTag("Player") && !hasAlreadyDamaged)
        {
            playerHealth.DamagePlayer(20);
            hasAlreadyDamaged = true;
            Destroy(gameObject);
        }
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
