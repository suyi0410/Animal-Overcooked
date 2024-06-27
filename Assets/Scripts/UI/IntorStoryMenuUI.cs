using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntorStoryMenuUI: MonoBehaviour
{
    [SerializeField] private Button IntoGameButton;
    

        private void Awake()
    {
        IntoGameButton.onClick.AddListener(() =>{
            Loader.Load(Loader.Scene.GameScene);
        });
        
        
        Time.timeScale = 1f;
    }
}
