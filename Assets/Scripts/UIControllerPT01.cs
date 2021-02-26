using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerPT01 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        int score = PlayerControllerPT01.GetPlayerScore();
        int goal = PlayerControllerPT01.GetPlayerMaxGoal();
        GetComponent<Text>().text = "Goal: " + score + "/" + goal;
    }
}
