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
    public void OnclickStart()
    {
        time = Time.time;
        Destroy(Floor);
        startFlag = true;
    }
    public void OnclickQuit()
    {
        UnityEngine.Application.Quit();
           UnityEditor.EditorApplication.isPlaying = false;
    }

    void Update()
    {
        if(startFlag)
        if(time + 3f < Time.time)
        {
        SceneChanger.SetSceneChange(true);
        startFlag = false;
        }
    }
}
