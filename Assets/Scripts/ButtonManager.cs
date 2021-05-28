using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

public SceneChanger SceneChanger;
public GameObject Floor;
float time;
bool startFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnclickToNextScene()
    {
        SceneChanger.SetSceneChange(true);
        //time = Time.time;
        //Destroy(Floor);
        //startFlag = true;
    }
    public void OnclickQuit()
    {
        UnityEngine.Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }

    void Update()
    {
        if(Input.GetButtonDown("joy_A"))
        {
            OnclickToNextScene();
        }

        if(Input.GetButtonDown("joy_B"))
        {
            OnclickQuit();
        }

        //if(startFlag)
        //{
        //    if(time + 2f < Time.time)
        //    {
        //        SceneChanger.SetSceneChange(true);
        //        startFlag = false;
        //    }
        //}
    }
}
