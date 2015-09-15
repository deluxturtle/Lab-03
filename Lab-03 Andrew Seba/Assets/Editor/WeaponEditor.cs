using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Andrew Seba
/// Description: Starts the weapon editor.
/// </summary>
[CustomEditor(typeof(WeaponController))]
public class WeaponEditor : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty controller = serializedObject.FindProperty("controllerWeapon");

        EditorGUILayout.PropertyField(controller);

        serializedObject.ApplyModifiedProperties();
    }
}
