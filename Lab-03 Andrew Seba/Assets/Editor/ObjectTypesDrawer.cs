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

        //Gather editable references to all of the variables needed off the script that are being edited
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
        



        switch ((ObjectType)objectType.enumValueIndex)
        {
            case ObjectType.BREAKABLE:
                Rect breakableRect = new Rect(position.x, position.y + 17, position.width, 15f);
                EditorGUI.PropertyField(breakableRect, breakablePoints);
                break;
            case ObjectType.DAMAGING:
                float offset = position.x;

                Rect damageTypeLabelRect = new Rect(offset, position.y + 17, position.width /2, 17f);
                offset += 35;
                EditorGUI.LabelField(damageTypeLabelRect, "Type");

                Rect damageTypeRect = new Rect(offset, position.y + 17, position.width / 3, 17f);
                offset += position.width / 3;
                EditorGUI.PropertyField(damageTypeRect, damageType, GUIContent.none);

                Rect damageAmountLabelRect = new Rect(offset, position.y + 17, position.width/2, 17f);
                offset += 55;
                EditorGUI.LabelField(damageAmountLabelRect, "Amount");

                Rect damageAmountRect = new Rect(offset, position.y + 17, position.width / 3, 17f);
                EditorGUI.PropertyField(damageAmountRect, damageAmount, GUIContent.none);
                break;
            case ObjectType.HEALING:
                offset = position.x;
                //Display "this item will heal the player's "health" by [] if it is "collided" with.
                Rect thisItemLabelRect = new Rect(offset, position.y + 17, 195f, 17f);
                EditorGUI.LabelField(thisItemLabelRect, "This item will heal the player's ");
                offset += 180f;

                //Health Option
                Rect healingTypeRect = new Rect(offset, position.y + 17, position.width /5, 17f);
                EditorGUI.PropertyField(healingTypeRect, healingType, GUIContent.none);
                offset += healingTypeRect.width;

                //the word "by"
                Rect byLableRect = new Rect(offset - 10f, position.y + 17, position.width /5, 17f);
                EditorGUI.LabelField(byLableRect, "by ");
                offset += 10f;

                //heal amount box
                Rect healAmountRect = new Rect(offset, position.y + 17, 60f, 17f);
                EditorGUI.PropertyField(healAmountRect, healingAmount, GUIContent.none);
                offset += 50f;

                Rect ifItIsLabelRect = new Rect(offset, position.y + 17, 70f, 17f);
                EditorGUI.LabelField(ifItIsLabelRect, "if it is");

                //reset offset.
                offset = position.x;

                Rect healingPickUpTypeRect = new Rect(offset, position.y + 17 *2, position.width / 4, 17f);
                EditorGUI.PropertyField(healingPickUpTypeRect, healingPickupType, GUIContent.none);
                offset = healingPickUpTypeRect.width;

                Rect withLabelRect = new Rect(offset, position.y + 17 * 2, position.width / 4, 17f);
                EditorGUI.LabelField(withLabelRect, "with.");
                break;
            case ObjectType.PASSABLE:
                offset = position.x;
                Rect noSettingsMessageRect = new Rect(offset, position.y + 17, position.width, 17f);
                EditorGUI.LabelField(noSettingsMessageRect, "There are no settings for a passable object.");
                break;
            case ObjectType.SOLID:
                Rect shouldMove = new Rect(position.x, position.y + 17, position.width, 17f);
                int index = solidMoving.boolValue ? 0 : 1;
                string[] options = new string[] { "Yes", "No" };
                index = EditorGUI.Popup(shouldMove, "Should it move?", index, options);
                solidMoving.boolValue = (index > 0) ? false : true;

                if (solidMoving.boolValue)
                {
                    float offsetS = position.x;
                    Rect startRect = new Rect(offsetS, position.y + 34, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.LabelField(startRect, "StartPoint");

                    startRect = new Rect(offsetS, position.y + 34, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.LabelField(startRect, "End Point");

                    offsetS = position.x;
                    startRect = new Rect(offsetS, position.y + 50, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.PropertyField(startRect, solidStart, GUIContent.none);

                    startRect = new Rect(offsetS, position.y + 50, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.PropertyField(startRect, solidEnd, GUIContent.none);
                }
                break;
        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }

}
