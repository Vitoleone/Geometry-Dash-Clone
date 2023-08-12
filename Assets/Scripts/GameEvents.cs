using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.OnGameEnd += OnGameEndCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnGameEnd -= OnGameEndCallback;
    }

    private void OnGameEndCallback()
    {
        GameManager.Instance.playerCam.m_Lens.Dutch = 0;
        GameManager.Instance.stageClearedPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
