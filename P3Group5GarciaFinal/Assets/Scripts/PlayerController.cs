using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 50;
    public GameObject playerProjectile;
    public float fireRate = 2f;
    public Vector3 offset = new Vector3 (0, 0, 2f);
    public float xRange = 35;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (transform.position.y > 22)
        {
            transform.position = new Vector3(transform.position.x, 22, transform.position.z);
        }
        if (transform.position.y < -8)
        {
            transform.position = new Vector3(transform.position.x, -8, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(playerProjectile, transform.position + offset, playerProjectile.transform.rotation);
        }
    }
}