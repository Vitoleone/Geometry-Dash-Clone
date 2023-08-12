using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ProgressIndıcator : MonoBehaviour
{
    private Transform _endLine;
    private Transform _playerTransform;
    private GameData _gameData;
    
    private TextMeshProUGUI _progressIndicatorText;
    private Image _progressIndicatorImage;
    
    private float _distance;
    private float _fullDistance;
    private float _progressValue;
    private float _playerStartPosition;
    
    public float maxProgressValue;

    private void Start()
    {
        InitilizeValues();
        
        _fullDistance = _endLine.transform.position.x - _playerTransform.position.x;
        _playerStartPosition = _playerTransform.position.x;
        
        StartCoroutine(UpdateIndicator());
    }

    IEnumerator UpdateIndicator()//Updates indicator value every 0.25 seconds(don't write in update for performance)
    {
        while (maxProgressValue < 100)
        {
            _distance = _endLine.transform.position.x - _playerTransform.position.x;
            _progressValue = 100 - (Mathf.InverseLerp(0, _fullDistance, _distance)*100);
            if (maxProgressValue < _progressValue)
            {
                _gameData.SaveProgress(maxProgressValue);
                maxProgressValue = _progressValue;
            }
            _progressIndicatorText.text = "%" + maxProgressValue.ToString("F0");
            _progressIndicatorImage.fillAmount = maxProgressValue/100;
            
            yield return new WaitForSeconds(0.25f);
        }
    }
    public void ResetIndicator()
    {
        maxProgressValue = 0;
    }
    void InitilizeValues()
    {
        _gameData = GameManager.Instance.gameData;
        _playerTransform = GameManager.Instance.player.transform;
        _endLine = GameManager.Instance.endLine.transform;
        _progressIndicatorImage = GameManager.Instance.progressImage;
        _progressIndicatorText = GetComponent<TextMeshProUGUI>();
        
    }
    
}
