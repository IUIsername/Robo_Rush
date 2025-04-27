using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player_Damage : MonoBehaviour, IPlayerDamage
{
    private const string PLAYER_DAMAGE = "Player Damage";

    [SerializeField] private int _damage;
    [SerializeField] private TMP_Text _damageText;

    private void Awake()
    {
        LoadDamage();
        UpdateUI();
    }

    private void SaveDamage()
    { 
        PlayerPrefs.SetInt(PLAYER_DAMAGE, _damage);
    }

    private void LoadDamage()
    {
        PlayerPrefs.GetInt(PLAYER_DAMAGE, _damage);
    }

    private void UpdateUI()
    {
        _damageText.SetText(_damage.ToString());
    }

    public int GetDamage() => _damage;



}
