using System;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject weapon;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform tip;
    [SerializeField] private float speed;
    private int ammo;
    private bool canShoot = true;

    [SerializeField] private GameObject deathScreen;
    private void Awake()
    {
        ammo = weapon.Ammo;
    }

    public void Shoot()
    {
        if (!canShoot || ammo <= 0) return;
        
        canShoot = false;
        
        GameObject bullet = Instantiate(bulletPrefab, tip.position, quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(tip.forward * speed);

        ammo--;

        bool hit = Physics.Raycast(tip.position, tip.forward, out RaycastHit hitInfo, weapon.Range);
        if (hit)
        {
            Health targetHealthComponent = hitInfo.collider.GetComponent<Health>();
            if (targetHealthComponent) targetHealthComponent.onDeath?.Invoke();
            if (hitInfo.collider.CompareTag("player") && deathScreen != null)
            {
                deathScreen.SetActive(true);
            }
        }

        Debug.DrawRay(tip.position, tip.forward, Color.red, 2f);
        
        Invoke(nameof(EnableCanShoot), weapon.FireRate);

        //Destroy(bullet,3);
    }

    void EnableCanShoot()
    {
        canShoot = true;
    }

    public int GetAmmo()
    {
        return ammo;
    }


}
