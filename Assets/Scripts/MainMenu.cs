using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuLevelBust _menuLevelBust;

    [SerializeField] private int indexLevelScene;
    [SerializeField] private int indexInfiniteScene;

    private void SetActiveScene(int indexScene)
    { 
        SceneManager.LoadScene(indexScene);
    }

    public void ActiveLevelScene()
    { 
        SetActiveScene(_menuLevelBust.CurrentLevel);
    }

    public void ActiveInfiniteScene()
    {
        SetActiveScene(indexInfiniteScene);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
