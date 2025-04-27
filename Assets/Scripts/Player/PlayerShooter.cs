using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distanceToTarget;

    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        _particleSystem.enableEmission = true;

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
