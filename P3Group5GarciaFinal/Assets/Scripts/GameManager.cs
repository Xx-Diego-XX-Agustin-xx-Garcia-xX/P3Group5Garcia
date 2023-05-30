using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private int Index;
    private float spawnRate = 0.005f;
    public bool isGameActive;
    public GameObject gameOverScreen;
    public GameObject healthBar;
    private PlayerHealth playerHealth;
    private PlayerController playerController;
    private Crosshair crosshair;
    private FollowPlayerCamera followPlayerCamera;
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("ZodiacAlphaA23").GetComponent<PlayerHealth>();
        playerController = GameObject.Find("ZodiacAlphaA23").GetComponent<PlayerController>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Crosshair>();
        followPlayerCamera = GameObject.Find("Main Camera").GetComponent<FollowPlayerCamera>();
    }

    public void StartGame()
    {
        isGameActive = true;
        InvokeRepeating("SpawnObstacles", 1, spawnRate);
        healthBar.SetActive(true);
        titleScreen.SetActive(false);
        playerController.enabled = true;
        crosshair.enabled = true;
        followPlayerCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacles()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-150, 150), Random.Range(-100, 100), 500);
        int Index = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[Index], spawnPos, obstacles[Index].transform.rotation);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        CancelInvoke();
        playerController.enabled = false;
        crosshair.enabled = false;
        followPlayerCamera.enabled = false;
    }
}
