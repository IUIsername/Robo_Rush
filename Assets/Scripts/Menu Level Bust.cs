using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevelBust : MonoBehaviour
{

    [SerializeField] private Text _levelText;
    private const string LEVEL_SCENE = "Level Scene";
    public int CurrentLevel = 0;

    private void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt(LEVEL_SCENE, 1);
        if(_levelText.text != null) 
            _levelText.text = $"Level{ CurrentLevel - 1}";
    }

    public void NextLevel()
    {
        if (CurrentLevel + 1 < SceneManager.sceneCountInBuildSettings)
        {
            CurrentLevel++;
            PlayerPrefs.SetInt(LEVEL_SCENE, CurrentLevel);
        }
    }
    
}
