using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public bool sceneFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneFlag)
        {
            sceneFlag = false;
            SceneManager.LoadScene(sceneName);
        }
        
    }

    public bool GetSceneChange()
    {
        return sceneFlag;
    }

    public void SetSceneChange(bool flag)
    {
        sceneFlag = flag;
    }
}
