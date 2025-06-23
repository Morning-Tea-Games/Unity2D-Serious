using System;
using UnityEngine;

namespace Rocket
{
    public class RocketView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _parts;

        public void Construct(Rocket model)
        {
            if (_parts.Length != model.Parts.Length)
            {
                throw new ArgumentException("The builder does not match the size of the rocket", nameof(model));
            }

            for (int i = 0; i < _parts.Length; i++)
            {
                _parts[i].sprite = model.Parts[i];
            }
        }
    }
}