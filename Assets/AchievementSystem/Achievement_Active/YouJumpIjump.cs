using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouJumpIjump : MonoBehaviour
{
    [SerializeField] GameObject hehe;
    [SerializeField]AchievementManager AchievementManager;
    [SerializeField] Camera camera; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { Vector3 mousePos=Input.mousePosition;
        Ray ray=camera.ScreenPointToRay(mousePos);
        RaycastHit raycastHit;
        bool heheOnclicked=Physics.Raycast(ray, out raycastHit);
        if (Input.GetMouseButtonDown(0))
        { 
            if (heheOnclicked)
            {
            AchievementManager.UnlockAchievement(Achevements.achG03);
            }

        }


    }
   
    
}
