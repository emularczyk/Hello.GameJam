using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;

    public int points = 0;
    public void UpdateScore(int addPoints)
    {
        points += addPoints;
        score.text = points.ToString();
        print("INFO SCORE: " + score);
    }

}
