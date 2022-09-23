using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private Transform currentWaypoint;
    private Coroutine lookCouroutine;
    private float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        StartRotating();
        //transform.LookAt(currentWaypoint);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed *  Time.deltaTime);
        if (Vector3.Distance(transform.position,currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            StartRotating();
            //transform.LookAt(currentWaypoint);
        }
    }

    public void StartRotating()
    {
        if(lookCouroutine != null)
        {
            StopCoroutine(lookCouroutine);
        }
        lookCouroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(currentWaypoint.position - transform.position);
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * speed;
            yield return null;
        }
    }


}
