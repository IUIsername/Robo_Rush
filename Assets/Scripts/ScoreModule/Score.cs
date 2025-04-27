using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    protected int _bestScore;
    
    protected void LoadScore() => _bestScore = PlayerPrefs.GetInt(BestScoreKey);
    protected void SaveScore() => PlayerPrefs.GetInt(BestScoreKey);

    protected void SetBestScore(int score)
    {
        if (_bestScore > score) return;

        _bestScore = score;
        SaveScore();
    }
}
