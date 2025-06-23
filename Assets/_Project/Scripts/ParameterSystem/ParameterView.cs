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
            _parametersField.text = string.Format(_format, part.Parameters[0].Name, part.Parameters[0].Value, 0f);
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