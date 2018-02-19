using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    private float speed;

    private int waypointIndex = 0;
    private Transform target;


    void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[waypointIndex];
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
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
