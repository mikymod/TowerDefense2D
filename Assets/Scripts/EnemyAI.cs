using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    // what to chase?
    public Transform target;
    // how many times each second we will update our path
    public float updateRate = 2f;

    // caching
    private Seeker seeker;
    private Rigidbody2D rb;

    // the calculated path
    public Path path;

    // the AI speed per second
    public float speed = 300f;
    public ForceMode2D forceMode;

    // the max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3f;

    // the waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private bool searchingForEndPoint = false;

    [HideInInspector]
    public bool pathIsEnded = false;

    private GameObject[] _ends;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        _ends = GameObject.FindGameObjectsWithTag("End");

        searchingForEndPoint = true;
        StartCoroutine(SearchForEndPoint());

        // start a new path to the target position and return the result to the OnPathComplete method
        if (target != null)
            seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    Transform GetNearestEnd()
    {
        Transform target = null;
        float distance = Mathf.Infinity;
        foreach (GameObject end in _ends)
        {
            float curDistance = Vector3.Distance(end.transform.position, transform.position);
            if (curDistance < distance)
            {
                distance = curDistance;
                target = end.transform;
            }
        }

        return target;
    }

    IEnumerator SearchForEndPoint()
    {
        searchingForEndPoint = false;
        target = GetNearestEnd();
        StartCoroutine(UpdatePath());
        yield return false;
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForEndPoint)
            {
                searchingForEndPoint = true;
                StartCoroutine(SearchForEndPoint());
            }
            yield return false;
        }

        if (target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }

        yield return new WaitForSeconds(1f / updateRate);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path. Did it have an error? " + p.error);

        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        StartCoroutine(SearchForEndPoint());

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                // Destroy(gameObject);
                return;
            }

            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        // direction to the next waypont
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        // move the  AI
        rb.AddForce(dir, forceMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

}
