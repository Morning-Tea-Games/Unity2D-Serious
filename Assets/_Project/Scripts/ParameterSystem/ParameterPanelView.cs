using Planet;
using Rocket;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ParameterSystem
{
    public class ParametrPanelView : MonoBehaviour
    {
        [SerializeField] private Transform _parametersContainer;
        [SerializeField] private ParameterView _paremeterPrefab;
        [SerializeField] private TMP_Text _planetField;
        [SerializeField] private Button _replace;
        [SerializeField] private RocketBuilder _builder;
        [SerializeField] private string _planetInfoFormat;

        private PlanetDataHolder _dataHolder;

        private void Awake()
        {
            _dataHolder = FindAnyObjectByType<PlanetDataHolder>();
            _planetField.text = string.Format(_planetInfoFormat, _dataHolder.CurrentPlanet.Config.Name);
            _replace.onClick.AddListener(ReplacePlanet);
        }

        private void OnDestroy()
        {
            _replace.onClick.RemoveListener(ReplacePlanet);
        }

        private void OnEnable()
        {
            RocketInteractor.OnChanged += OnInteractorChanged;
        }

        private void OnDisable()
        {
            RocketInteractor.OnChanged -= OnInteractorChanged;
        }

        private void OnInteractorChanged(RocketPartSO part)
        {
            var rocket = _builder.Build();
            var parameters = rocket.CalculateParameters();
            var planetParameters = _dataHolder.CurrentPlanet.Config.Parameters;

            RemoveAllChildren(_parametersContainer);

            if (parameters == null || planetParameters == null)
            {
                return;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                float planetValue = 0f;

                for (int j = 0; j < planetParameters.Length; j++)
                {
                    if (planetParameters[j].Name == parameters[i].Name)
                    {
                        planetValue = planetParameters[j].Value;
                        break;
                    }
                }

                Instantiate(_paremeterPrefab, _parametersContainer).Display(parameters[i].Name, parameters[i].Value, planetValue);
            }
        }

        private void RemoveAllChildren(Transform parent)
        {
            int childCount = parent.childCount;

            for (int i = childCount - 1; i >= 0; i--)
            {
                var child = parent.GetChild(i);
                Destroy(child.gameObject);
            }
        }

        private void ReplacePlanet()
        {
            SceneManager.LoadScene("Talk1");
        }
    }
}