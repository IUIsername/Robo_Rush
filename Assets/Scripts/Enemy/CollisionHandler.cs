using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] private int _indexMainScene;
    [SerializeField] private float _loadDelayCrash = 1.0f;
    [SerializeField] private float _loadDelayFinish = 1.0f;

    private Animator _animator;

    private InfinityEntityBoost _infinityEntityBoost;
    private MenuLevelBust _menuLevelBust;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _infinityEntityBoost = FindObjectOfType<InfinityEntityBoost>();
        _menuLevelBust = FindObjectOfType<MenuLevelBust>();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(_indexMainScene);
    }

    private void Crash()
    {
        _animator.SetTrigger("Die");
        StopPlayer();
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

    private void StopPlayer()
    {
        GetComponent<PlayerMove>().enabled = false;
        GetComponentInChildren<PlayerShooter>().gameObject.SetActive(false);
        FindObjectOfType<ScoreLevel>().CanCount();
    }

    private void Win()
    {
        _menuLevelBust?.NextLevel();
        _animator.SetTrigger("Win");
        StopPlayer();
        Invoke(nameof(LoadMainScene), _loadDelayFinish);
    }

    private void OnTrigerEnter(Collider other)
    {
        if (other.TryGetComponent(out FinishController finish))
        {
            Win();
            finish.AddBustLevel();
        }
        if (other.TryGetComponent(out BustEntityActivator activator))
        {
            if (activator.IsUse)
            {
                activator.IsUse = false;
            }
        }
    }
}
