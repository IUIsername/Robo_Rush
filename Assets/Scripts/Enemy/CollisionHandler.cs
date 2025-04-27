using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] private int _indexMainScene;
    [SerializeField] private float _loadDelayCrash;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(_indexMainScene);
    }

    private void Crash()
    {
        _animator.SetTrigger("Die");
        GetComponent<PlayerMove>().enabled = false;
        GetComponentInChildren<PlayerShooter>().gameObject.SetActive(false);
        FindObjectOfType<ScoreLevel>().CanCount();
        Invoke(nameof(LoadMainScene), _loadDelayCrash);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Attack();
            Crash();
        }
    }
}
