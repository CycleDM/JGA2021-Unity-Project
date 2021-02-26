using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class plant : MonoBehaviour
{
    public GameObject text1;
    public bool GameClear = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameClear)
        {
            text1.GetComponent<Text>().text = "Gamer Clear";
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "pickup")
        {
            GameClear = true;
        }
    }
}
