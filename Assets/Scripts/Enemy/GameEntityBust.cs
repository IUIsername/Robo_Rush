using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEntityBust : MonoBehaviour
{
    [SerializeField] protected int _multiplyEntityHP;

    public UnityEvent OnBustEvent;

    public int MultiplyEntityHP => _multiplyEntityHP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
