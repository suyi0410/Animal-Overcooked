using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AchievementNotificationController : MonoBehaviour
{
    [SerializeField] Text achievementTitleLable;
    private Animator ach_animator;

    private void Awake()
    {
        ach_animator = GetComponent<Animator>();
    }
    public void showNoticification(Achevement achievement)
    {
        achievementTitleLable.text = achievement.title ;
        ach_animator.SetTrigger("Appear");
    }
}
