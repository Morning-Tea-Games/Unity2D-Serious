using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[System.Serializable]
public class StatModifiers
{
    public string Name;
    public float value;
}


[CreateAssetMenu(menuName = "Rocket_Game/Planet")]

public class Parameters: ScriptableObject
{
    public StatModifiers[] statModifiers;
}
