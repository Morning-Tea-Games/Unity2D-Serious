using UnityEngine;

namespace Rocket
{
    public class RocketBuilder : MonoBehaviour
    {
        [SerializeField] private RocketInteractor[] _interactors;

        public Rocket Build()
        {
            var parts = new RocketPartSO[_interactors.Length];

            for (int i = 0; i < _interactors.Length; i++)
            {
                parts[i] = _interactors[i].CurrentPart;
            }

            return new Rocket(parts);
        }
    }
}