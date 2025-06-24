using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterView : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private string _valueFormat;

    public void Display(string name, float current, float target)
    {
        string state;
        float v = current / target * 100f;
        _bar.fillAmount = current / target;

        if (v <= 33f)
        {
            state = "плохо";
        }
        else if (v > 33f && v <= 66f)
        {
            state = "риск";
        }
        else
        {
            state = "оптимально";
        }

        _value.text = string.Format(_valueFormat, name, current, state);
    }
}