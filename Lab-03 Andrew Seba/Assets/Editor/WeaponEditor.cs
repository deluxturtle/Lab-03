using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WeaponController))]
public class WeaponEditor : Editor {

    //Weapon weaponScript;
    
    //void Awake()
    //{
    //    weaponScript = (Weapon)target;
    //}

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        //Toggle off shield and relic if 2 handed

        SerializedProperty controller = serializedObject.FindProperty("controllerWeapon");

        EditorGUILayout.PropertyField(controller);
        

        //weaponScript.damage = EditorGUILayout.Slider("Damage", weaponScript.damage, 0, 100);

        //weaponScript.upgradable = EditorGUILayout.Toggle("Upgradable", weaponScript.upgradable);

        serializedObject.ApplyModifiedProperties();
    }
}
