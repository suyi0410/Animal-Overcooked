using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoChangToMainMenu : MonoBehaviour
{
   
    public void StartMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }

   
}
