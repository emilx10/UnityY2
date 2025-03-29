using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Weapons")]
public class WeaponScriptableObject : ScriptableObject
{
    public float FireRate;
    public float Range;
    public float Damage;
    public int Ammo;
}
