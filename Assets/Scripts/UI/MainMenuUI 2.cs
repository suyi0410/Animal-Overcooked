using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI3: MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button achievement;
    [SerializeField] private Button options;

        private void Awake()
    {
        playButton.onClick.AddListener(() =>{
            Loader.Load(Loader.Scene.intor_storyBG);
        });
        
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        achievement.onClick.AddListener(() => {
            SceneManager.LoadScene("Achievement"); 
            });
        
        options.onClick.AddListener(() => {
            SceneManager.LoadScene("Options");
            
        });

        Time.timeScale = 1f;
    }
}
