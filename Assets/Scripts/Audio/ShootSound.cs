using UnityEngine;

public class ShootSound : MonoBehaviour
{
    public Weapon weapon;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && weapon != null)
        {
            if (CanShootNow())
            {
                audioSource.Play();
            }
        }
    }
    
    bool CanShootNow()
    {
        return weapon.GetAmmo() > 0;
    }
}
