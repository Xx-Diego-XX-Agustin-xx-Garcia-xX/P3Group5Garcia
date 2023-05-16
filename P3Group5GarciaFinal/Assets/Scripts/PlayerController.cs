using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool isGameOver = false;
    private float zBound = 0.01f;
    public float bound;
    public float force;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isGameOver == false)
        {
            if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.I)))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(new Vector3(0, force, 0));
            }
            else if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.J)))
            {
                rigidBody.AddForce(new Vector3(-force, 0, 0));
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.L)))
            {
                rigidBody.AddForce(new Vector3(force, 0, 0));
            }
        }
        if ((transform.position.x > bound) || (transform.position.x < -bound))
        {
            OnCollisionEnter();
        }
        else if ((transform.position.y > bound) || (transform.position.y < -bound))
        {
            OnCollisionEnter();
        }
        if ((transform.position.z > zBound) || (transform.position.y < -zBound))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    void OnCollisionEnter()
    {
        rigidBody.velocity = Vector3.zero;
        isGameOver = true;
        Debug.Log("Game Over!");
    }
}
