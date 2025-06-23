using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rocket
{
    public class RocketInteractor : MonoBehaviour, IPointerDownHandler
    {
        public Sprite CurrentSprite => _image.sprite;

        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _types;

        private int _currentType;

        public void OnPointerDown(PointerEventData eventData)
        {
            _currentType++;

            if (_currentType >= _types.Length)
            {
                _currentType = 0;
            }

            _image.sprite = _types[_currentType];
        }
    }
}