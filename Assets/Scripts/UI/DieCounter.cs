using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
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
    public void ResetDieCounter()
    {
        GameManager.Instance.gameData.ResetDieCount();
    }
}
