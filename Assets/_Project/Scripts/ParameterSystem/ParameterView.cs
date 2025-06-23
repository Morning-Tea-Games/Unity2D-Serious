using System.Text;
using Rocket;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParameterSystem
{
    public class ParametrView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _parametersField;
        [SerializeField] private Button _next;
        [SerializeField] private Button _previous;
        [SerializeField] private int _maxPages;
        [SerializeField] private string _format;

        [SerializeField] private TMP_Text _planetField;
        [SerializeField] private Button _replace;

        [SerializeField] private RocketBuilder _builder;

        private void OnEnable()
        {
            RocketInteractor.OnChanged += OnInteractorChanged;
            _next.onClick.AddListener(NextPage);
            _previous.onClick.AddListener(PreviousPage);
        }

        private void OnDisable()
        {
            RocketInteractor.OnChanged -= OnInteractorChanged;
            _next.onClick.RemoveListener(NextPage);
            _previous.onClick.RemoveListener(PreviousPage);
        }

        private void OnInteractorChanged(RocketPartSO part)
        {
            var rocket = _builder.Build();
            var parameters = rocket.CalculateParameters();

            if (parameters == null)
            {
                return;
            }

            StringBuilder sbuilder = new();

            for (int i = 0; i < parameters.Length; i++)
            {
                sbuilder.AppendLine(string.Format(_format, parameters[i].Name, parameters[i].Value, 0)); //TODO: Заменить 0 на цель для планеты
            }

            _parametersField.text = sbuilder.ToString();
        }

        private void NextPage()
        {
            _parametersField.pageToDisplay++;

            if (_parametersField.pageToDisplay > _maxPages)
            {
                _parametersField.pageToDisplay = 1;
            }
        }

        private void PreviousPage()
        {
            _parametersField.pageToDisplay--;

            if (_parametersField.pageToDisplay < 1)
            {
                _parametersField.pageToDisplay = _maxPages;
            }
        }
    }
}