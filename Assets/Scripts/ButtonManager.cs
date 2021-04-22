using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

public SceneChanger SceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnclickStart()
    {
        SceneChanger.SetSceneChange(true);
    }
    public void OnclickQuit()
    {
        UnityEngine.Application.Quit();
           UnityEditor.EditorApplication.isPlaying = false;
    }
}
