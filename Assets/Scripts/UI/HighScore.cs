using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent((typeof(TextMeshProUGUI)))]
public class HighScore : MonoBehaviour
{
   private TextMeshProUGUI _highScoreText;

   private void Start()
   {
      _highScoreText = GetComponent<TextMeshProUGUI>();
      _highScoreText.text = "Highscore: %" + GameManager.Instance.gameData.maxProgress.ToString("F0");
   }
   
}
