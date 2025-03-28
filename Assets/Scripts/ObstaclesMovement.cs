using System;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesPoints; 
    [SerializeField] private BarrelScriptableObject barrelStats; 
    [SerializeField] private float speed = 5f; 

    private bool isDestPoint1 = true; // Flag to check if the object is moving towards point 1 or point 2

    void Update()
    {
        // If the object is moving towards the first point
        if (isDestPoint1)
        {
            // If the object reaches the first point, change the destination to the second point
            if (Vector3.Distance(transform.position, obstaclesPoints[0].transform.position) < 1f)
                isDestPoint1 = false;
            else
                // Move the object towards the first point
                transform.position = new Vector3(
                    transform.position.x - (barrelStats.BarrelSpeedMod * speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            // If the object reaches the second point, destroy it
            if (Vector3.Distance(transform.position, obstaclesPoints[0].transform.position) < 1f)
            {
                Destroy(gameObject); 
                return; // Exit the update loop to stop any further movement after destruction
            }

           
        }
    }
}
