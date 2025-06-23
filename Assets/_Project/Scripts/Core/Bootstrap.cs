using UnityEngine;
using UnityEngine.UI;
using Rocket;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private RocketBuilder _rocketBuilder;
        [SerializeField] private RocketView _rocketPrefab;
        [SerializeField] private Button _buildButton;

        private void Awake()
        {
            _buildButton.onClick.AddListener(OnBuildButtonClick);
        }

        private void OnDestroy()
        {
            _buildButton.onClick.RemoveListener(OnBuildButtonClick);
        }

        private void OnBuildButtonClick()
        {
            var rocket = _rocketBuilder.Build();
            Instantiate(_rocketPrefab).Construct(rocket);
        }
    }
}