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
    [SerializeField] private Button cSMe;
    [SerializeField] private GameObject cSMeChar;
    [SerializeField] private GameObject youFMe;
    [SerializeField] AchievementManager AchievementManager;


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

        cSMe.onClick.AddListener(() =>
        {
            AchievementManager.UnlockAchievement(Achevements.achG1);
            cSMe.gameObject.SetActive(false);
            cSMeChar.SetActive(false);
            youFMe.gameObject.SetActive(true);


        });

        Time.timeScale = 1f;
    }
}
