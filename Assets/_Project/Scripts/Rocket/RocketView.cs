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
                throw new ArgumentException("The size of the rocket does not match the model", nameof(model));
            }

            for (int i = 0; i < _parts.Length; i++)
            {
                _parts[i].sprite = model.Parts[i].Sprite;
            }
        }
    }
}