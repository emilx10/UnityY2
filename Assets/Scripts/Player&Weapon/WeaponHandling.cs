using UnityEngine;

public class WeaponHandling : MonoBehaviour
{
    [SerializeField] private Transform gripPoint;
    [SerializeField] private Animator shootAnim;

    private Weapon currentCloseWeapon;
    private Weapon currentWeapon;
    
    private InputMaster input;
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Awake()
    {
        input = new InputMaster();

        input.Player.Equip.performed += _ => Equip();
        input.Player.Shoot.performed += _ =>
        {
            if (currentWeapon)
            {
                shootAnim.SetTrigger("LeftMouseClick");
                Invoke(nameof(Shoot), 0.3f);
                //shootAnim.SetBool("LeftMouseClick", false);
            }
        };
    }

    void Shoot()
    {
        currentWeapon.Shoot();
    }

    void Equip()
    {
        if (!currentCloseWeapon) return;

        currentWeapon = currentCloseWeapon;
        currentCloseWeapon = null;
        
        currentWeapon.transform.SetParent(gripPoint);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.rotation = gripPoint.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon = other.GetComponent<Weapon>();
        if (!weapon) return;
        
        currentCloseWeapon = weapon;
    }

    private void OnTriggerExit(Collider other)
    {
        currentCloseWeapon = null;
    }
}
