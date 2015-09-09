using UnityEngine;
using System.Collections;

public enum Classification
{
    TWOHANDED,
    ONEHANDED,
    OFFHAND
}

public enum WeaponType
{
    SWORD,
    SHIELD,
    RELIC,
    HAMMER,
    SYCTH
}

public class Weapon : MonoBehaviour {

    public Classification weaponClass;
    public WeaponType weaponType;
    public float damage;
    public bool upgradable;
}
