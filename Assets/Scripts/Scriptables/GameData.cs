using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    //Created for save current stage's data, maybe used in future?
    public float maxProgress;
    public int playerDieCount;

    public void SaveProgress(float progress)
    {
        if (progress >= maxProgress)
        {
            maxProgress = progress;
            EventManager.Instance.OnHighScoreChanged.Invoke(GameManager.Instance.highScoreText);
        }
    }

    public void IncreaseDieCount()
    {
        playerDieCount++;
    }

    public void ResetDieCount()
    {
        playerDieCount = 0;
    }
    
}
