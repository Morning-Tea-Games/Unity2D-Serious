using System;
using UnityEngine;

namespace ParameterSystem
{
    [Serializable]
    public class Parameter
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
    }
}