using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntityBust : GameEntityBust
{
    private const string MULTIPLY_ENEMY_HP = "MultiplyEnemyHP";

    private void LoadBust()
    {
        _multiplyEntityHP = PlayerPrefs.GetInt(MULTIPLY_ENEMY_HP);
    }

    private void SaveBust()
    {
        PlayerPrefs.SetInt(MULTIPLY_ENEMY_HP, _multiplyEntityHP);
    }
    public void AddEntityBust()
    {
        _multiplyEntityHP++;
        SaveBust();
    } 
}
