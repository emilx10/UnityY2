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

    private void Awake()
    {
        ammo = weapon.Ammo;
    }

    public void Shoot()
    {
        if (!canShoot || ammo <= 0) return;
        
        canShoot = false;
        //Invoke(nameof(Shoot), 0.25f);
        GameObject bullet = Instantiate(bulletPrefab, tip.position, quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(tip.forward * speed);

        ammo--;

        bool hit = Physics.Raycast(tip.position, tip.forward, out RaycastHit hitInfo, weapon.Range);
        if (hit)
        {
            Debug.Log("Hit");
            Health targetHealthComponent = hitInfo.collider.GetComponent<Health>();
            if (targetHealthComponent) targetHealthComponent.onDeath?.Invoke();
        }

        Debug.DrawRay(tip.position, tip.forward, Color.red, 2f);
        
        Invoke(nameof(EnableCanShoot), weapon.FireRate);

        Destroy(bullet,3);
    }

    public float GetRange()
    {
        Debug.Log(weapon==null);
        Debug.Log(weapon.Range);
        return weapon.Range;
    }

    void EnableCanShoot()
    {
        canShoot = true;
    }


}
