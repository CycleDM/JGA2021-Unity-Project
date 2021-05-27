using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    PlayerController PlayerController;
    public GameObject ScoreObject;
    private int Score;
    private Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = ScoreObject.GetComponent<Text> ();
        Score = PlayerController.GetExp();
    }

    // Update is called once per frame
    void Update()
    {
       
        ScoreText.text = "SCORE : " + Score;
    }
}
