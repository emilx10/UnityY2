using UnityEngine;
using UnityEngine.Events;

public class newLaserCheck : MonoBehaviour
{
    
    public UnityEvent onLaserHit;
    public UnityEvent<string> onLaserHitText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))  
        {
            
            onLaserHit.Invoke();
            onLaserHitText.Invoke("player 1 slowed!");
        }
    }
}
