using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 targetPosition; // End point for the arrow to travel to
    public float destroyDelay = 1f; // Delay before arrow destroys itself after reaching its destination

    private bool isActivated = false; // A flag to check if the arrow is activated
    public GameObject deathScreen;

    // This function will be called from the trigger zone to activate the arrow
    public void ActivateArrow()
    {
        if (!isActivated)
        {
            StartCoroutine(MoveArrow());
            isActivated = true;
        }
    }

    private IEnumerator MoveArrow()
    {
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;

        // Move arrow toward target position
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);

            yield return null;
        }

        // Destroy the arrow after reaching the destination or delay
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("Dead BOI");
            other.gameObject.GetComponentInChildren<Animator>().SetTrigger("dead");
            if (deathScreen != null)
            {
                int buildIndex = SceneManager.GetActiveScene().buildIndex;
                int levelIndex = buildIndex - 1;
                deathScreen.SetActive(true);
                deathScreen.GetComponent<DeathScreenUI>().Show(levelIndex);
            }
            Destroy(gameObject);
        }
    }
}
