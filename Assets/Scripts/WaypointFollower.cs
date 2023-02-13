using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic script for a game object to move between waypoints

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; //A list of waypoints, meaning it can go between as many waypoints as we want
    int currentWaypointIndex = 0;
    [SerializeField] float speed = 1f;
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex ++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
