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
    SCYTH
}

[System.Serializable]
public class Weapon{

    public Classification weaponClass;
    public WeaponType weaponType;
    public float damage;
    public bool upgradable;

    
    

}
