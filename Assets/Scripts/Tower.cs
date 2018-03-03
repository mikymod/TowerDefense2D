using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Settings")]
    public float fireRate = 0.5f;
    private float _fireCountdown;
    public float range = 2f;
    public float turnSpeed = 2f;
    public float damage = 50f;
    public int cost = 100;

    [Header("Required")]
    public Transform head;
    public GameObject projectile;
    public Transform firePoint;

    private Animator _animator;
    private Transform _target;
    private Enemy _enemy;

    private const string ENEMY_TAG = "Enemy";

    void Start()
    {
        _animator = gameObject.GetComponentInChildren<Animator>();
        _fireCountdown = fireRate;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
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
            this._target = nearestEnemy.transform;
            this._enemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            this._target = null;
        }
    }

    void Update()
    {
        if (_target == null)
        {
            Idle();
            return;
        }

        if (_fireCountdown <= 0.0f)
        {
            Shoot();
            _fireCountdown = fireRate;
        }

        LockOnTarget();

        _fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        head.rotation = Quaternion.Lerp(head.rotation, newRotation, turnSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        _animator.SetTrigger("Shoot");

        if (projectile != null)
        {
            GameObject projGO = Instantiate(projectile, firePoint.position, head.rotation);
            Projectile projScript = projGO.GetComponent<Projectile>();
            projScript.target = _target;
            return;
        }

        _enemy.TakeDamage(damage);
    }

    void Idle()
    {
        _animator.ResetTrigger("Shoot");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 255f);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
