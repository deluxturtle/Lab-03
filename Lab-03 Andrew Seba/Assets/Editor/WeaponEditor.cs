using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor {

    Weapon weaponScript;
    
    void Awake()
    {
        weaponScript = (Weapon)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        //Toggle off shield and relic if 2 handed
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponClass"));

        SerializedProperty controller = serializedObject.FindProperty("weaponType");
        EditorGUILayout.PropertyField(controller);


        //EditorGUI.indentLevel++;
        //switch (weaponScript.weaponClass)
        //{
        //    case Classification.TWOHANDED:
        //        weaponScript.swordType = EditorGUILayout.Toggle("Sword", weaponScript.swordType);
        //        weaponScript.hammerType = EditorGUILayout.Toggle("Hammer", weaponScript.hammerType);
        //        weaponScript.scythType = EditorGUILayout.Toggle("Scyth", weaponScript.scythType);
        //        EditorGUILayout.LabelField("Shield [Off Hand Weapon Only]");

        //        weaponScript.shieldType = false;
        //        EditorGUILayout.LabelField("Relic [Off Hand Weapon Only");
        //        weaponScript.relicType = false;
        //        break;
        //    case Classification.ONEHANDED:
        //        weaponScript.swordType = EditorGUILayout.Toggle("Sword", weaponScript.swordType);
        //        weaponScript.hammerType = EditorGUILayout.Toggle("Hammer", weaponScript.hammerType);
        //        EditorGUILayout.LabelField("Scyth [Two Handed Only]");
        //        weaponScript.scythType = false;
        //        EditorGUILayout.LabelField("Shield [Off Hand Weapon Only]");
        //        weaponScript.shieldType = false;
        //        EditorGUILayout.LabelField("Relic [Off Hand Weapon Only");
        //        weaponScript.relicType = false;
        //        break;
        //    case Classification.OFFHAND:
        //        weaponScript.swordType = false;
        //        EditorGUILayout.LabelField("Hammer [One or Two Handed Only");
        //        weaponScript.hammerType = false;
        //        EditorGUILayout.LabelField("Scyth [Two Handed Only]");
        //        weaponScript.scythType = false;

        //        break;
        //}
        //EditorGUI.indentLevel--;

        weaponScript.damage = EditorGUILayout.Slider("Damage", weaponScript.damage, 0, 100);

        weaponScript.upgradable = EditorGUILayout.Toggle("Upgradable", weaponScript.upgradable);

        serializedObject.ApplyModifiedProperties();
    }
}
