using UnityEngine;
using System.Collections;

public enum ArmourType
{
    CLOTH,
    LEATHER,
    MAIL,
    PLATE
}

[System.Serializable]
public class ArmourTypes{
    public ArmourType type;
    public bool cloth = false;
    public bool leather = false;
    public bool mail = false;
    public bool plate = false;

}
