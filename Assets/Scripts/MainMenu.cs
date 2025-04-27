using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int indexLevelScene;
    [SerializeField] private int indexInfiniteScene;

    private void SetActiveScene(int indexScene)
    { 
        SceneManager.LoadScene(indexScene);
    }

    public void ActiveLevelScene()
    { 
        SetActiveScene(indexLevelScene);
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
