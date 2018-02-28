using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int money = 5;

    public float startHealth = 100f;
    private float health;
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0.0f)
        {
            Die();
        }
    }

    void Die()
    {
        Player.Money += money;
        Destroy(gameObject);
    }
}
