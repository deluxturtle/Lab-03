using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Generic Weapon Class that holds its values.
/// </summary>

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
    SCYTH
}

[System.Serializable]
public class Weapon{

    public Classification weaponClass;
    public WeaponType weaponType;
    public float damage;
    public bool upgradable;

}
