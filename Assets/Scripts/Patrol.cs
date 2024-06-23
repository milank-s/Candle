using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;   // Array to hold the patrol points
    public float moveSpeed = 5f;       // Speed at which the object moves between points
    
    private int currentPointIndex = 0; // Index of the current point the object is moving towards

    void Start()
    {
        // Initialize starting point
        transform.position = patrolPoints[0].position;
    }

    void Update()
    {
        // Move towards the current patrol point
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);

        // Rotate towards the current patrol point
        RotateTowards(patrolPoints[currentPointIndex].position);
        
        // Check if we have reached the current patrol point
        if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.1f)
        {
            // Move to the next point in the array
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Create a rotation looking towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Adjust the last parameter to control rotation speed
    }

    // Visualize the patrol points in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.1f);
        }
    }
}

