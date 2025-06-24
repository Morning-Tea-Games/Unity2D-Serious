using ParameterSystem;
using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(fileName = "New rocket part", menuName = "Rocket/New part")]
    public class RocketPartSO : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Parameter[] Parameters { get; private set; }
    }
}