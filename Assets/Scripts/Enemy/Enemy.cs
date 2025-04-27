using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    private Animator _animator;
    private IPlayerDamage _playerDamage;
    private int _countCoinsPerKill = 10;
    private void Awake()
    {
        CalculateHP();
        _animator = GetComponent<Animator>();
        _playerDamage = FindObjectOfType<Player_Damage>();
    }

    void Update()
    {
        
    }

    private void UpdateUI()
    {
        _healthText.SetText(_currentHealth.ToString());
    }

    private void CalculateHP()
    { 
        _currentHealth = _maxHealth;
        UpdateUI();
    }

    private void Die()
    {
        _animator.SetTrigger("Die");
        FindObjectOfType<Bank>().AddCoin(_countCoinsPerKill);
        _healthText.gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
        UpdateUI();
    
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(_playerDamage.GetDamage());
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
