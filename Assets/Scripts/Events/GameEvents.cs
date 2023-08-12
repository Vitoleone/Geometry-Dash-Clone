using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private void Start()//This script created for controlling game flow.
    {
        EventManager.Instance.OnGameEnd += OnGameEndCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnGameEnd -= OnGameEndCallback;
    }

    private void OnGameEndCallback()
    {
        GameManager.Instance.stageClearedPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
