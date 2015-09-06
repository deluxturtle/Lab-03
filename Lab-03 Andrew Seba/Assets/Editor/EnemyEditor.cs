using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor {

    Enemy enemyScript;
    bool factionSettings = false;
    bool armourSettings = false;

    bool armourTypes = false;

    void Awake()
    {
        enemyScript = (Enemy)target;
    }

    public override void OnInspectorGUI()
    {
        factionSettings = EditorGUILayout.Foldout(factionSettings, "Faction Settings");
        if (factionSettings)
        {
            EditorGUI.indentLevel++;
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("factionType"), true);
            EditorGUI.indentLevel--;
        }
        serializedObject.ApplyModifiedProperties();
        armourSettings = EditorGUILayout.Foldout(armourSettings, "Armour Settings");
        if (armourSettings)
        {
            EditorGUI.indentLevel++;
            serializedObject.Update();
            EditorGUILayout.Toggle();
            EditorGUI.indentLevel--;
        }

    }

}
