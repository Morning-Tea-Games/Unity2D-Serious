using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rocket
{
    public class RocketInteractor : MonoBehaviour, IPointerDownHandler
    {
        public static event Action<RocketPartSO> OnChanged;
        public RocketPartSO CurrentPart { get; private set; }
        [field: SerializeField] public RocketPartSO[] Parts { get; private set; }
        [SerializeField] private Image _image;

        private int _currentIndex;

        public void OnPointerDown(PointerEventData eventData)
        {
            Next();
        }

        private void Next()
        {
            _currentIndex++;

            if (_currentIndex >= Parts.Length)
            {
                _currentIndex = 0;
            }

            _image.sprite = Parts[_currentIndex].Sprite;
            CurrentPart = Parts[_currentIndex];
            OnChanged?.Invoke(CurrentPart);
        }
    }
}