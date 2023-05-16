using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject playerPrefab;
    public float frequency;
    public float position;
    public float rangeMax;
    public float rangeMin;
    public float timer;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            position = Random.Range(rangeMin, rangeMax);
            transform.position = new Vector3(position, position, 25);
            Instantiate(obstaclePrefabs[obstacleIndex], transform.position, transform.rotation);
            timer = frequency;
        }
        if (playerPrefab != null)
        {
            Time.timeScale = 2.5f;

        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
