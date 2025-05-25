using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private const string DAMAGE_CONST = "DAMAGE_CONST";
    [SerializeField] private int _countAddDamage;
    [SerializeField] private int _damageCost;
    [SerializeField] private TMP_Text _damageCostText;

    private Bank _bank;
    private Player_Damage _playerDamage;

    private void Load() =>
        _damageCost = PlayerPrefs.GetInt(DAMAGE_CONST, _damageCost);

    private void Save() =>
       PlayerPrefs.SetInt(DAMAGE_CONST, _damageCost);

    private void UpdateUI() =>
        _damageCostText.SetText(_damageCost.ToString());
    private void Awake()
    {
        Load();
        _bank = FindObjectOfType<Bank>();
        _playerDamage = FindObjectOfType<Player_Damage>();
        UpdateUI();
    }

    public void BuyDamage()
    {
        if (_playerDamage != null)
        {
            _playerDamage.AddDamage(_countAddDamage);
            _damageCost += (int)(1.30f * _damageCost);
            Save();
            UpdateUI();
        }
    }
}
