using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AchievementItemControler : MonoBehaviour
{
    [SerializeField]Image unlockedIcon;
    [SerializeField]Image lockedIcon;

    [SerializeField]Text titleLabel;
    [SerializeField]Text descriptionLabel;
    
    public bool unlocked;
    public Achevement achievement;

    public void RefreshView()
    {
        titleLabel.text=achievement.title;
        descriptionLabel.text=achievement.description;

        unlockedIcon.enabled=unlocked;
        lockedIcon.enabled=!unlocked;
    }
    private void OnValidate()
    {
        RefreshView();
    }
}
