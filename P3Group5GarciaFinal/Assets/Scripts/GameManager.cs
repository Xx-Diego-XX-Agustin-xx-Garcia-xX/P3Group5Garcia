using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private int Index;
    private float spawnRate = 0.005f;
    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
           InvokeRepeating("SpawnObstacles", 1, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnObstacles ()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-150, 150), Random.Range(-100, 100), 500);
        int Index = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[Index], spawnPos, obstacles[Index].transform.rotation);
    }
}
