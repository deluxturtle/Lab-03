using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor {

    Weapon weaponScript;
    bool twoHandedLimits = false;
    
    void Awake()
    {
        weaponScript = (Weapon)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponClass"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponType"));
        if(weaponScript.weaponClass == Classification.TWOHANDED)
        {
            twoHandedLimits = true;
        }
        else
        {
            twoHandedLimits = false;
        }

        //

        


        //

        weaponScript.damage = EditorGUILayout.Slider("Damage", weaponScript.damage, 0, 100);
        weaponScript.upgradable = EditorGUILayout.Toggle("Upgradable", weaponScript.upgradable);

        serializedObject.ApplyModifiedProperties();
    }
}
