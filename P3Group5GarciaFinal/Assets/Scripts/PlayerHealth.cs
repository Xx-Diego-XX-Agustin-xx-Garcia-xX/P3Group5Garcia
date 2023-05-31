using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    private GameManager gameManager;
    public bool Dead;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }

    public void HealPlayer(int heal)
    {
        curHealth += heal;

        healthBar.SetHealth(curHealth);
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            Dead = true;
            gameManager.GameOver();
        }

        if (curHealth > maxHealth)
        {
            curHealth = 100;
        }
    }
}
