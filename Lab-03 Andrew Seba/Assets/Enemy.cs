using UnityEngine;
using System.Collections;

public enum FactionType
{
    AGRESSIVE,
    NEUTRAL,
    PASSIVE
}

public class Enemy : MonoBehaviour {

    public FactionType factionTypes;
    public float health;
    public float mana;

    public bool armourCloth;
    public bool armourLeather;
    public bool armourMail;
    public bool armourPlate;
	

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(string.Format("Cloth<{0}>, Leather<{1}>, Mail<{2}>, Plate<{3}>", armourCloth, armourLeather, armourMail, armourPlate));
            Debug.Log(string.Format("Health<{0}>, Mana<{1}>", health, mana));
        }
    }
}
