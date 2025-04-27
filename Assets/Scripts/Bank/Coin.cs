using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private int maxCoinCost;
    [SerializeField] private int minCoinCost;
    private int _coinCost;

    private Bank _bank;
    private void Start()
    {
        _bank = FindObjectOfType<Bank>();
        _coinCost = Random.Range(minCoinCost, maxCoinCost);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _bank.AddCoin(_coinCost);

            if (coinSound) AudioSource.PlayClipAtPoint(coinSound, transform.position);
           
            Destroy(gameObject);
        }
    }
}
