using Rocket;
using TMPro;
using UnityEngine;
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
            RemoveAllChildren(_parametersContainer);

            if (parameters == null)
            {
                return;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                Instantiate(_paremeterPrefab, _parametersContainer).Display(parameters[i].Name, parameters[i].Value, 30f); //TODO: Цель от планеты
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
    }
}