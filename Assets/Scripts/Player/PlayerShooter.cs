using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentCountManaText;
    [SerializeField] private float _countMana;
    [SerializeField] private int _shootManaCost;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distanceToTarget;

    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponent<ParticleSystem>();

        UpdateUI();
    }

    private void UpdateUI()
    {
        _currentCountManaText.text = Mathf.Round(_countMana).ToString();
    }

    public void ChangeMana(float amount)
    {
        _countMana += amount;
        if (_countMana <= 0)
        {
            _countMana = 0;
        }
        UpdateUI();
    }

    public void Shoot()
    {
        if (_countMana <= 0)
        { 
            StopShoot();
            return;
        }
        _particleSystem.enableEmission = true;

        _countMana -= Time.deltaTime * _shootManaCost;
        UpdateUI();

        if (!_audioSource.isPlaying)
        { 
            _audioSource.Play();
        }
        
    }

    private void StopShoot()
    {
        _particleSystem.enableEmission = false;
        _audioSource.Stop();
    }
}
