using System.Collections;
using ParameterSystem;
using Rocket;
using TMPro;
using UnityEngine;

namespace Flight
{
    public class FlightAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _startPos;
        [SerializeField] private TMP_Text _result;
        private RocketView _rocket;
        private ParameterView[] _parameters;

        private void Awake()
        {
            _result.gameObject.SetActive(false);
        }

        private void Start()
        {
            _rocket = FindAnyObjectByType<RocketView>();
            _rocket.transform.SetPositionAndRotation(_startPos.position, _startPos.rotation);
            _parameters = ParameterView.Instances.ToArray();
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (_rocket.transform.position.x <= 12.5f)
            {
                _rocket.transform.Translate(0f, 10f * Time.deltaTime, 0f);
                yield return new WaitForEndOfFrame();
            }

            bool isSuccess = CheckParameters();

            _result.text = isSuccess ? "Успех!" : "Крушение!";
            _result.gameObject.SetActive(true);
        }

        private bool CheckParameters()
        {
            int riskCount = 0;

            foreach (ParameterView param in _parameters)
            {
                if (param.State == "плохо")
                {
                    return false;
                }

                if (param.State == "риск")
                {
                    riskCount++;
                }
            }

            if (riskCount >= 2)
            {
                return false;
            }

            ParameterView.Instances.Clear();

            return true;
        }
    }
}