using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();  // List to store the arrows in the scene
    public float delayBetweenArrows = 0.5f;                    // Delay between each arrow activation

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("player"))
        {
            // Activate all arrows in the list
            StartCoroutine(ActivateArrows());
        }
    }

    private IEnumerator ActivateArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            // Activate the arrow by calling ActivateArrow on its ObstaclesMovement script
            ObstaclesMovement arrowMovement = arrow.GetComponent<ObstaclesMovement>();
            if (arrowMovement != null)
            {
                arrowMovement.ActivateArrow();
            }

            // Wait for the specified delay before activating the next arrow
            yield return new WaitForSeconds(delayBetweenArrows);
        }
    }
}
