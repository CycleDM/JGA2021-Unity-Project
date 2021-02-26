using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rubbish : MonoBehaviour
{
    public GameObject text;
    public int waitTime = 15;
    public float totalTime = 0;
    public GameObject exit;
    public bool onReccycle = false;
    public bool pick = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(onReccycle)
        {
            if(Input.GetKey(KeyCode.G)) pick = false;
            if(!pick)
            {
                if(waitTime<=0)
                {
                    GetComponent<Renderer>().material.color = Color.green;
                    transform.GetComponent<Transform>().position = exit.GetComponent<Transform>().position + new Vector3(0,0.8f,0);
                    text.GetComponent<Text>().text = " ";
                    onReccycle = false;
                }
                else
                {
                    CountDown();
                }
            }
        }
        else
        {
            text.GetComponent<Text>().text = " ";
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enter")
        {
            onReccycle = true;
        }
    }

    public void CountDown()
    {
        totalTime += Time.deltaTime;
        if(totalTime>=1)
        {
            waitTime--;
            totalTime = 0;
        }
        text.GetComponent<Text>().text = "waitTime : " + waitTime.ToString();
    }

}
