using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) // Make sure the object has the "Player" tag
        {
            Debug.Log("Player Entered the door trigger area");
            gameObject.SetActive(false); // Deactivate the door object
        }
    }
}
