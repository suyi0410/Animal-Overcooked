using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Button TutorialButton;
    [SerializeField] private Button EasyButton;
    [SerializeField] private Button NomalButton;
    [SerializeField] private Button HardButton;
    [SerializeField] private Button ExitButton;

    private void Awake()
    {
        TutorialButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene_Tutorial);
        });

        EasyButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene_Easy);
        });
        ExitButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        Time.timeScale = 1f;
    }
}