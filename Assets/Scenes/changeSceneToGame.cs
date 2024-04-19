using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangesceneToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //点击鼠标右键切换场景
        if (Input.GetMouseButtonDown(1))
        {
            //  Application.LoadLevel("SampleScene");
            SceneManager.LoadScene("GameScene");
        }

    }
}