using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private void Start()//This script created for controlling game flow.
    {
        EventManager.Instance.OnGameEnd += OnGameEndCallback;
        EventManager.Instance.OnHighScoreChanged += OnHighScoreChangedCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnGameEnd -= OnGameEndCallback;
        EventManager.Instance.OnHighScoreChanged += OnHighScoreChangedCallback;
    }

    private void OnGameEndCallback()
    {
        GameManager.Instance.stageClearedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnHighScoreChangedCallback(TextMeshProUGUI highScoreText)
    {
        highScoreText.text = "Highscore: %" + GameManager.Instance.gameData.maxProgress.ToString("F0");
    }
}
