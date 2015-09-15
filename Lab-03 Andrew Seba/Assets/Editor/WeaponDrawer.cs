using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Andrew Seba
/// Description: Displays the custom layout of the weapon editor.
/// </summary>
[CustomPropertyDrawer(typeof(Weapon))]
public class WeaponDrawer : PropertyDrawer {

    float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect weaponTypeDisplay = new Rect(position.x + position.width/3, position.y, position.width, 15f);

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty weaponType = property.FindPropertyRelative("weaponType");
        SerializedProperty weaponClass = property.FindPropertyRelative("weaponClass");
        SerializedProperty damage = property.FindPropertyRelative("damage");
        SerializedProperty upgradable = property.FindPropertyRelative("upgradable");
        EditorGUI.LabelField(new Rect(position.x, position.y, position.width/2, 15f), "Weapon Classification: ");
        EditorGUI.PropertyField(weaponTypeDisplay, weaponClass, GUIContent.none);

        EditorGUI.indentLevel++;
        switch ((Classification)weaponClass.enumValueIndex)
        {
            case Classification.TWOHANDED:
                Rect twoHandedRect = new Rect(position.x, position.y + 17, position.width, 15f);
                int index = weaponType.enumValueIndex;
                string[] optionsTwoHanded = new string[] { "Sword", "","", "Hammer", "Scyth" };
                index = EditorGUI.Popup(twoHandedRect, "Weapon Type: ", index, optionsTwoHanded);

                //set it to a valid option
                if (index == 1 || index == 2)
                {
                    index = 0;
                }

                switch (index)
                {
                    case 0:
                        weaponType.enumValueIndex = 0;
                        break;
                    case 3:
                        weaponType.enumValueIndex = index;
                        break;
                    case 4:
                        weaponType.enumValueIndex = index;
                        break;
                }
                break;

            case Classification.ONEHANDED:
                Rect oneHandedRect = new Rect(position.x, position.y + 17, position.width, 15f);
                index = weaponType.enumValueIndex;
                string[] optionsOneHanded = new string[] { "Sword", "", "", "Hammer", "" };
                index = EditorGUI.Popup(oneHandedRect, "Weapon Type: ", index, optionsOneHanded);

                //set it to a valid option
                if (index == 1 || index == 2 || index == 4)
                {
                    index = 0;
                }

                switch (index)
                {
                    case 0:
                        weaponType.enumValueIndex = 0;
                        break;
                    case 3:
                        weaponType.enumValueIndex = index;
                        break;
                }
                break;

            case Classification.OFFHAND:
                Rect offHandRect = new Rect(position.x, position.y + 17, position.width, 15f);
                index = weaponType.enumValueIndex;
                string[] optionsOffHand = new string[] { "", "Shield", "Relic", "", "" };
                index = EditorGUI.Popup(offHandRect, "Weapon Type: ", index, optionsOffHand);

                //set it to a valid option.
                if (index == 0 || index == 3 || index == 4)
                {
                    index = 1;
                }

                switch (index)
                {
                    case 1:
                        weaponType.enumValueIndex = index;
                        break;
                    case 2:
                        weaponType.enumValueIndex = index;
                        break;
                }
                break;

        }


        EditorGUI.Slider(new Rect(position.x, position.y + 34, position.width, 17f), damage, 0, 100);

        //Display Upgradable Option.
        if (weaponType.enumValueIndex != 3)
        {
            Rect upgradeRect = new Rect(position.x, position.y + 51, position.width / 2, 17f);
            upgradable.boolValue = EditorGUI.Toggle(upgradeRect, "Upgradable", upgradable.boolValue);
        }
        else
        {
            upgradable.boolValue = false; //set to false if not applicable.
        }

        EditorGUI.indentLevel--;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }
}
