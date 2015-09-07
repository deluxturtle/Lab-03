using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor {

    Enemy enemyScript;
    bool healthSettings = false;
    bool armourSettings = false;


    void Awake()
    {
        enemyScript = (Enemy)target;
    }

    public override void OnInspectorGUI()
    {
        //armourType = serializedObject.FindProperty("armour");
        //clothArmour = serializedObject.FindProperty("armourCloth");
        armourSettings = EditorGUILayout.Foldout(armourSettings, "Armour Settings");
        if (armourSettings)
        {
            EditorGUI.indentLevel++;
            enemyScript.armourCloth = EditorGUILayout.Toggle("Cloth", enemyScript.armourCloth);
            enemyScript.armourLeather = EditorGUILayout.Toggle("Leather", enemyScript.armourLeather);
            enemyScript.armourMail = EditorGUILayout.Toggle("Mail", enemyScript.armourMail);
            enemyScript.armourPlate = EditorGUILayout.Toggle("Plate", enemyScript.armourPlate);
            EditorGUI.indentLevel--;

        }

        enemyScript.health = EditorGUILayout.FloatField("Health:", enemyScript.health);
        enemyScript.mana = EditorGUILayout.FloatField("Mana: ", enemyScript.mana);

        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("factionTypes"));
        serializedObject.ApplyModifiedProperties();

    }

}
