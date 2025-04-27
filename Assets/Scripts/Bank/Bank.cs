using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class Bank : MonoBehaviour
{
    private const string BankSave = "Bank Coin";

    [SerializeField] private TMP_Text currentCoinCountText;
    private int _currentCoinCount;

    private void Awake()
    {
        LoadCoin();
        UpdateUI();
    }

    public void UpdateUI()
    { 
        currentCoinCountText.SetText(_currentCoinCount.ToString());
    }
    private void LoadCoin() => _currentCoinCount = PlayerPrefs.GetInt(BankSave, 0);

    private void SaveCoin() => PlayerPrefs.SetInt(BankSave, _currentCoinCount);

    public void AddCoin(int amount)
    {
        _currentCoinCount += amount;
        UpdateUI();
        SaveCoin();
    }

    public bool IsCanSpeed(int amount)
    {
        if (_currentCoinCount - amount >= 0)
        {
            _currentCoinCount -= amount;
            UpdateUI();
            SaveCoin();
            return true;
        }
        return false;
    }
    
}
