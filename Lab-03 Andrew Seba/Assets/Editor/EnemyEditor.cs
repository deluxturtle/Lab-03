using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Andrew Seba
/// Description: Custom editor for enemy.
/// </summary>
[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor {

    Enemy enemyScript;
    bool healthSettings = false;
    bool manaOption = false;
    bool armourSettings = false;
    bool mailOption = true;
    bool attackDamageSettings = false;
    bool weaponType = false;


    void Awake()
    {
        enemyScript = (Enemy)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        enemyScript.enemyName = EditorGUILayout.TextField("Name: ", enemyScript.enemyName);

        healthSettings = EditorGUILayout.Foldout(healthSettings, "Health");
        if (healthSettings)
        {
            EditorGUI.indentLevel++;
            enemyScript.health = EditorGUILayout.Slider("Health:", enemyScript.health, 0f, 100f);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("factionTypes"));


        armourSettings = EditorGUILayout.Foldout(armourSettings, "Armour Settings");
        if (armourSettings)
        {
            EditorGUI.indentLevel++;

            enemyScript.armourLeather = EditorGUILayout.Toggle("Leather", enemyScript.armourLeather);
            if(mailOption == false)
            {
                EditorGUILayout.LabelField("Mail");
            }
            else
            {
                enemyScript.armourMail = EditorGUILayout.Toggle("Mail", enemyScript.armourMail);
            }
            enemyScript.armourPlate = EditorGUILayout.Toggle("Plate", enemyScript.armourPlate);
            EditorGUI.indentLevel--;

        }

        

        attackDamageSettings = EditorGUILayout.Foldout(attackDamageSettings, "Attack Damage Settings");
        if(attackDamageSettings)
        {
            EditorGUI.indentLevel++;
            SerializedProperty attackDamage = serializedObject.FindProperty("attackDamage");
            EditorGUILayout.PropertyField(attackDamage);
            if(enemyScript.attackDamage == AttackDamage.PHYSICAL)
            {
                manaOption = false;
                enemyScript.armourCloth = false;
            }
            else
            {
                manaOption = true;
                
            }

            EditorGUI.indentLevel++;
            if (manaOption)
            {
                enemyScript.mana = EditorGUILayout.Slider("Mana: ", enemyScript.mana, 0,100);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("spellType"));
                EditorGUILayout.LabelField("Special Armour");
                EditorGUI.indentLevel++;
                enemyScript.armourCloth = EditorGUILayout.Toggle("Cloth", enemyScript.armourCloth);
                EditorGUI.indentLevel--;

            }
            else
            {
                enemyScript.mana = 0;
            }
            EditorGUI.indentLevel--;

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();
        weaponType = EditorGUILayout.Foldout(weaponType, "Weapon Type");
        if (weaponType)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("attackTypes"));

            if(enemyScript.attackTypes == AttackType.MELEE)
            {
                EditorGUILayout.BeginHorizontal();
                enemyScript.twoHanded = EditorGUILayout.Toggle("Two Handed", enemyScript.twoHanded);
                if(enemyScript.twoHanded == true)
                {
                    EditorGUILayout.LabelField("Mail Armour Disabled.");
                    enemyScript.armourMail = false;
                    mailOption = false;

                }
                else
                {
                    mailOption = true;
                }
                EditorGUILayout.EndHorizontal();
                enemyScript.duelWeild = EditorGUILayout.Toggle("Duel Weild", enemyScript.duelWeild);

            }
            else
            {
                enemyScript.twoHanded = false;
                enemyScript.duelWeild = false;
            }

            EditorGUI.indentLevel--;
        }
        
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("attackDamage"));




        serializedObject.ApplyModifiedProperties();

    }

}
