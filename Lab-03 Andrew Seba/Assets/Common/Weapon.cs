using UnityEngine;
using System.Collections;

public enum Classification
{
    TWOHANDED,
    ONEHANDED,
    OFFHAND
}

public class Weapon : MonoBehaviour {

    public Classification weaponClass;
    public float damage;
    public bool upgradable;

    public bool swordType;
    public bool shieldType;
    public bool relicType;
    public bool hammerType;
    public bool scythType;
}
