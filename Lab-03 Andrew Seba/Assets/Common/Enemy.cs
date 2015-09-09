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

public enum SpellType
{
    FIRE,
    FROST,
    ARCANE
}

public class Enemy : MonoBehaviour {

    public string enemyName;

    public FactionType factionTypes;
    public float health;
    public float mana;

    public bool armourCloth;
    public bool armourLeather;
    public bool armourMail;
    public bool armourPlate;

    public bool twoHanded;
    public bool duelWeild;

    public AttackType attackTypes;
    public AttackDamage attackDamage;
    public SpellType spellType;
	
    


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(string.Format("Cloth<{0}>, Leather<{1}>, Mail<{2}>, Plate<{3}>", armourCloth, armourLeather, armourMail, armourPlate));
            Debug.Log(string.Format("Health<{0}>, Mana<{1}>", health, mana));
            Debug.Log(string.Format("AttackDamage: {0}", attackDamage));
        }
    }
}
