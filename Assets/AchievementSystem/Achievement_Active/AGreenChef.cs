using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGreenChef : MonoBehaviour
{
    public AchievementManager achievementManager;

    // Update is called once per frame
    void Update()
    {
        achievementManager.UnlockAchievement(Achevements.achT01/*Achievement id*/);
        // call achievementManager to Unlock the Achievement
    }
}
