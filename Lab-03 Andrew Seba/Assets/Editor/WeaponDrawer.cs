using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(Weapon))]
public class WeaponDrawer : PropertyDrawer {

    float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect weaponTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty weaponType = property.FindPropertyRelative("weaponType");
        SerializedProperty weaponClass = property.FindPropertyRelative("weaponClass");
        SerializedProperty damage = property.FindPropertyRelative("damage");
        SerializedProperty upgradable = property.FindPropertyRelative("upgradable");

        EditorGUI.PropertyField(weaponTypeDisplay, weaponClass, GUIContent.none);

        switch ((Classification)weaponClass.enumValueIndex)
        {
            case Classification.TWOHANDED:
                Rect twoHandedRect = new Rect(position.x, position.y + 17, position.width, 15f);
                int index = weaponType.enumValueIndex;
                string[] optionsTwoHanded = new string[] { "Sword", "","", "Hammer", "Scyth" };
                index = EditorGUI.Popup(twoHandedRect, "Weapon Type: ", index, optionsTwoHanded);
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

                if(weaponType.enumValueIndex == 0 || weaponType.enumValueIndex == 4)
                {
                    //EditorGUI.Toggle()
                }
                break;
            case Classification.ONEHANDED:
                Rect oneHandedRect = new Rect(position.x, position.y + 17, position.width, 15f);
                index = weaponType.enumValueIndex;
                string[] optionsOneHanded = new string[] { "Sword", "", "", "Hammer", "" };
                index = EditorGUI.Popup(oneHandedRect, "Weapon Type: ", index, optionsOneHanded);
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
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }
}
