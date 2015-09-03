using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjectTypes))]
public class ObjectTypesDrawer : PropertyDrawer {

    float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect objectTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty objectType = property.FindPropertyRelative("type");

        SerializedProperty breakablePoints = property.FindPropertyRelative("breakablePoints");

        SerializedProperty solidMoving = property.FindPropertyRelative("solidMoving");
        SerializedProperty solidStart = property.FindPropertyRelative("solidStart");
        SerializedProperty solidEnd = property.FindPropertyRelative("solidEnd");

        SerializedProperty damageType = property.FindPropertyRelative("damageType");
        SerializedProperty damageAmount = property.FindPropertyRelative("damageAmount");

        SerializedProperty healingType = property.FindPropertyRelative("healingType");
        SerializedProperty healingPickupType = property.FindPropertyRelative("healingPickupType");
        SerializedProperty healingAmount = property.FindPropertyRelative("healingAmount");


        //Display the initial dropdown for the user to select what type of object this is
        //with no label
        EditorGUI.PropertyField(objectTypeDisplay, objectType, GUIContent.none);

        Debug.Log(objectType.enumValueIndex);

        EditorGUI.EndProperty();

        switch ((ObjectType)objectType.enumValueIndex)
        {
            case ObjectType.BREAKABLE:
                Rect breakableRect = new Rect(position.x, position.y + 17, position.width, 15f);
                EditorGUI.PropertyField(breakableRect, breakablePoints);
                break;
            case ObjectType.DAMAGING:
                float offset = position.x;

                Rect damageTypeLabelRect = new Rect(position.x, position.y + 17, 35f, 17f);
                offset += 35;
                EditorGUI.LabelField(damageTypeLabelRect, "Type");
                break;
            case ObjectType.HEALING:
                break;
            case ObjectType.PASSABLE:
                break;
            case ObjectType.SOLID:
                break;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }

}
