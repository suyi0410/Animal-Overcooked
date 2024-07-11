using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AGreenChef : MonoBehaviour
{
    public AchievementManager achievementManager;

    private void Start()
    {
        Scene crrentScene= SceneManager.GetActiveScene();
        string sceneName=crrentScene.name;
        if (sceneName == "GameScene_Tutorial")
        { 
            achievementManager.UnlockAchievement(Achevements.achT01/*Achievement id*/);
        // call achievementManager to Unlock the Achievement

        }
    }
    // Update is called once per frame
    void Update()
    {
       
       
    }
}
