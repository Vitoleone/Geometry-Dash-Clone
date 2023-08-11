using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DieCounter : MonoBehaviour
{
    private TextMeshPro _dieCounterText;
    void Start()
    {
        GameManager.Instance.gameData.ResetDieCount();
        _dieCounterText = GetComponent<TextMeshPro>();
        UpdateDieCounter();
    }

    public void UpdateDieCounter()
    {
        _dieCounterText.text = "Attempt " + GameManager.Instance.gameData.playerDieCount;
    }
}
