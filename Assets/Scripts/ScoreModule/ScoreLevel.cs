using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLevel : Score
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultipliner;
    private bool _shouldCount = true;
    private float _score;

    private void Count()
    {
        _score += Time.deltaTime * scoreMultipliner;
        scoreText.SetText(Mathf.FloorToInt(_score).ToString());
    
    }

    private void Update()
    {
        if (!_shouldCount) return;
        Count();
    }

    public void CanCount()
    {
        _shouldCount = false;
        SetBestScore(Mathf.FloorToInt(_score));
    }
}
