using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParameterSystem
{
    public class ParameterView : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private TMP_Text _value;
        [SerializeField] private string _valueFormat;

        private string _state;

        public static List<ParameterView> Instances { get; private set; } = new List<ParameterView>();

        public string State
        {
            get { return _state; }
        }

        private void OnEnable()
        {
            Instances.Add(this);
        }

        private void OnDisable()
        {
            // Instances.Remove(this);
        }

        public void Display(string name, float current, float target)
        {
            float v = current / target * 100f;
            _bar.fillAmount = current / target;

            if (v <= 33f)
            {
                _state = "плохо";
            }
            else if (v > 33f && v <= 66f)
            {
                _state = "риск";
            }
            else
            {
                _state = "оптимально";
            }

            _value.text = string.Format(_valueFormat, name, current, _state);
        }
    }
}