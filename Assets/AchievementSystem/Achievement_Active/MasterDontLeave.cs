using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDontLeave : MonoBehaviour
{
    [SerializeField] GameObject airWall;
    [SerializeField] GameObject airWall1;
    [SerializeField] GameObject airWall2;
    [SerializeField] GameObject airWall3;
    [SerializeField] GameObject player;
    [SerializeField] AchievementManager AchievementManager;
    
    void Update()
    {
        if (player.transform.position.x<airWall.transform.position.x)
        {
            AchievementManager.UnlockAchievement(Achevements.achG02);
        }
        if (player.transform.position.x > airWall1.transform.position.x)
        {
            AchievementManager.UnlockAchievement(Achevements.achG02);
        }
        if (player.transform.position.z > airWall2.transform.position.z)
        {
            AchievementManager.UnlockAchievement(Achevements.achG02);
        }
        if (player.transform.position.z < airWall3.transform.position.z)
        {
            AchievementManager.UnlockAchievement(Achevements.achG02);
        }
    }
}
