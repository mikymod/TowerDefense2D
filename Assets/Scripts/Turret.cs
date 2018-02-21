using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate = 0.5f;
    private float fireCountdown;
    public float range = 2f;
    public float turnSpeed = 2f;
    public float damage = 50f;
    public int cost = 100;
    public Transform head;

    public GameObject projectile;
    public Transform firePoint;

    private Animator animator;
    private Transform target;
    private Enemy enemy;
    private const string enemyTag = "Enemy";

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        fireCountdown = fireRate;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            this.target = nearestEnemy.transform;
            this.enemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            this.target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            Idle();
            return;
        }

        if (fireCountdown <= 0.0f)
        {
            Shoot();
            fireCountdown = fireRate;
        }

        LockOnTarget();

        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        head.rotation = Quaternion.Lerp(head.rotation, newRotation, turnSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");

        if (projectile != null)
        {
            GameObject projGO = Instantiate(projectile, firePoint.position, head.rotation);
            Projectile projScript = projGO.GetComponent<Projectile>();
            projScript.target = target;
            return;
        }

        enemy.TakeDamage(damage);
    }

    void Idle()
    {
        animator.ResetTrigger("Shoot");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 255f);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
