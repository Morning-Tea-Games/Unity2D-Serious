using ParameterSystem;
using UnityEngine;

namespace Planet
{
    [CreateAssetMenu(fileName = "New planet", menuName = "Planets/New planet")]
    public class PlanetSO : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Parameter[] Parameters { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}