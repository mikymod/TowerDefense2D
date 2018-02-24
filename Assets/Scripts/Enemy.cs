using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    private float speed;

    public int money = 5;

    private int waypointIndex = 0;
    private Transform target;

    public float startHealth = 100f;
    private float health;
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[waypointIndex];
        health = startHealth;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Move to waypoint
        Vector3 dir = target.position - transform.position;
        Vector3 translation = dir.normalized * speed * Time.deltaTime;
        transform.Translate(translation);

        // If waypoint is reached, proced to the other
        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            NextWayPoint();
        }

        // Reset speed
        speed = startSpeed;
    }

    void NextWayPoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Player.Health--;
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
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
