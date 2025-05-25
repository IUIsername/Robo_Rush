using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostMana : MonoBehaviour
{
    [SerializeField] private float _maxAddMana;
    [SerializeField] private float _minAddMana;
    [SerializeField] private TMP_Text _addManaText;
    [SerializeField] private AudioClip _collectSound;
    private float _currentMana;

    private void Awake()
    {
        _currentMana = Random.Range(_minAddMana, _maxAddMana);
        _addManaText.text = Mathf.Round(_currentMana).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            FindObjectOfType<PlayerShooter>().ChangeMana(_currentMana);

            if (_collectSound)
            {
                AudioSource.PlayClipAtPoint(_collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
