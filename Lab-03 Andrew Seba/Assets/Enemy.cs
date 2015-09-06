using UnityEngine;
using System.Collections;

public enum FactionType
{
    AGRESSIVE,
    NEUTRAL,
    PASSIVE
}

public enum AttackType
{
    MELEE,
    RANGED
}

public enum AttackDamage
{
    PHYSICAL,
    SPELL
}

public enum SpellTypes
{
    FIRE,
    FROST,
    ARCANE
}

public enum WeaponType
{
    TWO_HANDED,
    DUAL_WEILD
}


public class Enemy: MonoBehaviour{
    public FactionType factionType;


    public float Health;
    public float Mana;

    public AttackType attackType;
    public AttackDamage attackDamage;
    public SpellTypes spellTypes;
    public WeaponType weaponType;

    
    
}
