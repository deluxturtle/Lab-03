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
public class Weapon : MonoBehaviour{

    public Classification weaponClass;
    public float damage;
    public bool upgradable;

    public WeaponType weaponType;
    public bool swordType;
    public bool shieldType;
    public bool relicType;
    public bool hammerType;
    public bool scythType;
    

}
