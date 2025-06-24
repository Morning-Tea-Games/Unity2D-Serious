using UnityEngine;

namespace Planet
{
    public class PlanetDataHolder : MonoBehaviour
    {
        public PlanetView CurrentPlanet { get; private set; }

        private void Awake() => DontDestroyOnLoad(gameObject);

        public void SetPlanet(PlanetView planet) => CurrentPlanet = planet;
    }
}