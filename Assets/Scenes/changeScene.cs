using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Changescene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public float timer = 2.0f; // 定时2秒

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("intor_storyBG");
            timer = 2.0f;
        }
    }

    /*void Update()
    {
        //点击鼠标右键切换场景
        if (Input.GetMouseButtonDown(1))
        {
            //  Application.LoadLevel("SampleScene");
            SceneManager.LoadScene("intor_storyBG");
        }

    }*/
}

/*public float timer = 2.0f; // 定时2秒
void Update() {
    timer -= Time.deltaTime;
    if (timer <= 0) {
        doSomething();
        timer = 2.0f;
    }
}*/