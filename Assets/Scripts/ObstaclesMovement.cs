using System;
using UnityEngine;
using UnityEngine.AI;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] public GameObject[] ObstaclesPoints;
    [SerializeField] public float Velocity;

    private bool isDestPoint1 = true;
    
    void Update()
    {
        if (isDestPoint1)
        {
            if (Vector3.Distance(transform.position, ObstaclesPoints[0].transform.position) < 1f)
                isDestPoint1 = false;
            else
                transform.position = new Vector3(
                    transform.position.x - (Velocity * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            if (Vector3.Distance(transform.position, ObstaclesPoints[1].transform.position) < 1f)
                isDestPoint1 = true;
            else
                transform.position = new Vector3(
                    transform.position.x + (Velocity * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
}
