using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject ClockHand;
    public float LimitedTime = 90f;
    float CurrentTime;
    float TimeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = Time.time;
        if(Time.time - TimeCounter >= 1f)
        {
            TimeCounter = Time.time;
            ClockHand.GetComponent<RectTransform>().Rotate(0, 0, 270.0f / LimitedTime);
        }

        if(CurrentTime >= LimitedTime)
        {

        }
    }
}
