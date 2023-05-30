using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    public float missileSpeed = 75;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
    }
}
