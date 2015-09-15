using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Gets scripts values and dipslays to console.
/// </summary>
public class ScriptDisplayValues : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Display Weapon Info in console
        Weapon targetWeapon = transform.GetComponent<WeaponController>().controllerWeapon;
        Enemy targetEnemy = transform.GetComponent<Enemy>();

        if(targetWeapon != null)
        {
            Debug.Log("<i>_____Weapon Info_____</i>" +
                "\n<b>Class</b>: " + targetWeapon.weaponClass +
                "\n<b>Type</b>: " + targetWeapon.weaponType +
                "\n<b>Damage</b>: " + targetWeapon.damage +
                "\n<b>Upgradable</b>: " + targetWeapon.upgradable +
                "\n");
            //Debug.Log("<b>Weapon Class</b>: " + targetWeapon.weaponClass);
            //Debug.Log("<b>Weapon Type</b>: " + targetWeapon.weaponType);
            //Debug.Log("<b>Damage</b>: " + targetWeapon.damage);
            //Debug.Log("<b>Upgradable</b>: " + targetWeapon.upgradable);
        }
        else
        {
            Debug.Log("No weapon controller attached to object.");
        }

        if(targetEnemy != null)
        {
            Debug.Log("<i>_____Enemy Info_____</i>" +
                "\n<b>Name</b>: " + targetEnemy.enemyName +
                "\n<b>Faction</b>: " + targetEnemy.factionTypes +
                "\n<b>Health</b>: " + targetEnemy.health +
                "\n<b>Mana</b>: " + targetEnemy.mana +
                "\n\n<i>_Can Wear_</i>" +
                "\n<b>Cloth</b>: " + targetEnemy.armourCloth +
                "\n<b>Leather</b>: " + targetEnemy.armourLeather +
                "\n<b>Mail</b>: " + targetEnemy.armourMail +
                "\n<b>Plate</b>: " + targetEnemy.armourPlate +
                "\n\n<i>_Can Use_</i>" +
                "\n<b>Two Handed</b>: " + targetEnemy.twoHanded +
                "\n<b>Duel Weild</b>: " + targetEnemy.duelWeild +
                "\n\n<i>_Attack_</i>" +
                "\n<b>Type</b>: " + targetEnemy.attackTypes +
                "\n<b>Damage</b>: " + targetEnemy.attackDamage +
                "\n\n<i>_Spell_</i>" +
                "\n<b>Type</b>: " + targetEnemy.spellType +
                "\n"
                );
        }
        else
        {
            Debug.Log("No enemy script attached to object.");
        }
    }


}
