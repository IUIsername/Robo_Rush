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

    private GameEntityBust _gameEntityBust;
    private void Awake()
    {
        _gameEntityBust = FindObjectOfType<GameEntityBust>();
        _gameEntityBust.OnBustEvent.AddListener(CalculateHP);

        CalculateHP();

        _animator = GetComponent<Animator>();
        _playerDamage = FindObjectOfType<Player_Damage>();
    }

    void Start()
    {
        
    }

    private void UpdateUI()
    {
        _healthText.SetText(_currentHealth.ToString());
    }

    private void CalculateHP()
    { 
        _currentHealth = _maxHealth;
        _currentHealth += _gameEntityBust.MultiplyEntityHP;
        UpdateUI();
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        _healthText.gameObject.SetActive(false);
        _animator.SetTrigger("Die");
        FindObjectOfType<Bank>().AddCoin(_countCoinsPerKill);        
        _gameEntityBust.OnBustEvent.RemoveListener(CalculateHP);
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
        if (other.TryGetComponent(out PlayerShooter playerShooter))
        { 
            playerShooter.Shoot();
        }

        TakeDamage(_playerDamage.GetDamage());
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
