using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    public float maxProgress;
    public int playerDieCount;

    public void SaveProgress(float progress)
    {
        if (progress >= maxProgress)
        {
            maxProgress = progress;
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
