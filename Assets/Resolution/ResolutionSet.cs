using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ResolutiuonSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResolutiuonChange(int type) 
    {
     if (type == 1) { Screen.SetResolution(1920,1080, false);}
     if (type == 2) { Screen.SetResolution(1920, 1080, true); }

    }

    public void gotoTheScene(string temp) { SceneManager.LoadScene(temp);}
}
