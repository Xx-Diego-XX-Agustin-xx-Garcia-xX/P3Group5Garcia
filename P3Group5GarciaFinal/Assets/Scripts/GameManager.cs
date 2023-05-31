using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject controlsScreen;
    public GameObject titleScreenMusic;
    public GameObject gameScreenMusic;
    public GameObject gameOverMusic;
    public GameObject virgosBlessingScreen;
    public GameObject ariesWrathScreen;
    public GameObject pauseScreen;
    private bool paused;
    public GameObject sagittariusDashScreen;
    private int score;
    private float time;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gameScreen;
    public TextMeshProUGUI gameOverTimeText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject loreScreen;
    public AudioSource gameAudioSource;

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
        titleScreen.SetActive(false);
        gameScreen.SetActive(true);
        playerController.enabled = true;
        crosshair.enabled = true;
        followPlayerCamera.enabled = true;
        gameScreenMusic.SetActive(true);
        titleScreenMusic.SetActive(false);
        score = 0;
        time = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive == true)
        {
            Pause();
        }

        if (isGameActive == true)
        {
            time += Time.deltaTime;
            TimeDisplay(time);
        }
    }

    void TimeDisplay (float timeDisplay)
    {
        timeDisplay += 1;

        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        gameOverTimeText.text = string.Format("Time Surived: " + "{0:00}:{1:00}", minutes, seconds);
    }

    void SpawnObstacles()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-150, 150), Random.Range(-100, 100), 500);
        int ObstacleIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[ObstacleIndex], spawnPos, obstacles[ObstacleIndex].transform.rotation);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        CancelInvoke();
        playerController.enabled = false;
        crosshair.enabled = false;
        followPlayerCamera.enabled = false;
        gameScreenMusic.SetActive(false);
        gameOverMusic.SetActive(true);
        sagittariusDashScreen.SetActive(false);
        virgosBlessingScreen.SetActive(false);
        ariesWrathScreen.SetActive(false);
        gameOverScoreText.text = "Final Score: " + score;
    }

    public void ControlsScreen()
    {
        titleScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void LoreScreen()
    {
        titleScreen.SetActive(false);
        loreScreen.SetActive(true);
    }

    public void LoreScreenBackButton()
    {
        titleScreen.SetActive(true);
        loreScreen.SetActive(false);
    }

    public void ControlsScreenBackButton()
    {
        titleScreen.SetActive(true);
        controlsScreen.SetActive(false);
    }

    void Pause()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            gameScreen.SetActive(false);
            Time.timeScale = 0;
            gameAudioSource.Pause();
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            gameAudioSource.Play();
            gameScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
