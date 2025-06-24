using UnityEngine;

namespace Planet
{
    public class PlanetView : MonoBehaviour
    {
        [field: SerializeField] public PlanetSO Config { get; private set; }
        [SerializeField] private PlanetDataHolder _dataHolder;

        public void Construct(PlanetSO config) => Config = config;

        public void Choose() => _dataHolder.SetPlanet(this);

        public PlanetSO GetConfig() => Config;
    }
}