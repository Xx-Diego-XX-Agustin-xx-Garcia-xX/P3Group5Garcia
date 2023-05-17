using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
	private Rigidbody rigidBody;
	public float scrollSpeed;
	void Start()
	{
        	rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = new Vector3(0, 0, scrollSpeed);
	}
	void Update()
	{
        	if (transform.position.z < 0)
		{
			Destroy(gameObject);
		}
	}
}
