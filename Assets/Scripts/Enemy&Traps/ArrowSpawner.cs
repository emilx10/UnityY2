using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public float delayBetweenArrows = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            StartCoroutine(ActivateArrows());
        }
    }

    private IEnumerator ActivateArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            ObstaclesMovement arrowMovement = arrow.GetComponent<ObstaclesMovement>();
            if (arrowMovement != null)
            {
                arrowMovement.ActivateArrow();
            }

            yield return new WaitForSeconds(delayBetweenArrows);
        }
    }
}
