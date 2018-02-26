using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform _target;
    public Transform target
    {
        get { return _target; }
        set { _target = value; }
    }

    public GameObject explosioneHolePrefab;

    private float speed = 1f;
    // private float distance;
    private float startTime;
    private float radius = 0.75f;
    private float damage = 50f;

    private Vector3 currenttargetPos;

    void Start()
    {
        startTime = Time.time;
        // currenttargetPos = target.position;
        // distance = Vector3.Distance(transform.position, currenttargetPos);
    }

    void Update()
    {
        if (target != null)
            currenttargetPos = target.position;

        Vector3 dir = (currenttargetPos - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, currenttargetPos);
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionJourney = distanceCovered / distance;
        transform.position = Vector3.Lerp(transform.position, currenttargetPos, fractionJourney);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90f);
        transform.rotation = rotation;

        if (Vector3.Distance(transform.position, currenttargetPos) < 0.1f)
        {
            Hit();
            CollateralDamage(currenttargetPos);
            Destroy(gameObject);
        }
    }

    void Hit()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform target)
    {
        Enemy e = target.GetComponent<Enemy>();

        if (e != null)
            e.TakeDamage(damage);
    }

    void CollateralDamage(Vector3 targetPos)
    {
        GameObject explosionHole = Instantiate(explosioneHolePrefab, targetPos, Quaternion.identity);
        Destroy(explosionHole, 2f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 255f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
