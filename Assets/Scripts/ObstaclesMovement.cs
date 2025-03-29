using System.Collections;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 targetPosition; // End point for the arrow to travel to
    public float destroyDelay = 1f; // Delay before arrow destroys itself after reaching its destination

    private bool isActivated = false; // A flag to check if the arrow is activated
    private Animator playerAnimator;  // Reference to player's Animator
    private ParticleSystem bloodParticles;  // Reference to blood particle system
    private bool isDead = false;  // To check if the death animation is playing

    private GameObject player;  // Reference to the player object

    private void Start()
    {
        // Find the player object in the scene
        player = GameObject.FindGameObjectWithTag("player");

        // Get references to the Animator and ParticleSystem from the player's children
        playerAnimator = player.GetComponentInChildren<Animator>();
        bloodParticles = player.GetComponentInChildren<ParticleSystem>();
    }

    // This function will be called from the trigger zone to activate the arrow
    public void ActivateArrow()
    {
        if (!isActivated && !isDead)
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
            if (isDead) break;  // Stop moving if player is dead

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
            // Trigger the "dead" animation
            playerAnimator.SetTrigger("dead");

            // Play the blood particle effect when dead animation starts
            bloodParticles.Play();

            // Stop the movement of the arrow
            isDead = true;

            // Destroy the arrow after a delay
            Destroy(gameObject);
        }
    }
}
