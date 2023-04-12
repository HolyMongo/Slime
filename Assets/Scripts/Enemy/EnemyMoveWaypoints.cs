using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWaypoints : MonoBehaviour
{
    // Stores a reference to the waypoint system this object will use
    [SerializeField] private EnemyWaypoints waypoints;

    //How fast the enemy will move
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    //Current waypoint that the object is moving towards
    private Transform currentWaypoint;

    private void Start()
    {
        //Will set this obj to the first waypoint
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Set the next waypoint target to move towards
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
       
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
           
        }
    }
}
