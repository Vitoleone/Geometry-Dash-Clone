using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ProgressIndıcator : MonoBehaviour
{
    [SerializeField] private Transform endLine;
    [SerializeField] private Transform playerTransform;
    private TextMeshProUGUI _progressIndicatorText;
    private float _distance;
    private float _fullDistance;
    private float _progressValue;
    private float _maxProgressValue;
    private float _playerStartPosition;

    private void Start()
    {
        _fullDistance = endLine.transform.position.x - playerTransform.position.x;
        _playerStartPosition = playerTransform.position.x;
        _progressIndicatorText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateIndicator());
    }

    IEnumerator UpdateIndicator()
    {
        while (_maxProgressValue < 100)
        {
            _distance = endLine.transform.position.x - playerTransform.position.x;
            _progressValue = 100 - (Mathf.InverseLerp(0, _fullDistance, _distance)*100);
            if (_maxProgressValue < _progressValue)
            {
                _maxProgressValue = _progressValue;
            }
            _progressIndicatorText.text = "%" + _maxProgressValue.ToString("F0");
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
