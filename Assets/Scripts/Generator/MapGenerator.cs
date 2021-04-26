using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour 
{
    public static int chunkCountX = 3;
    public static int chunkCountY = 3;

    // Start is called before the first frame update
    void Start () 
    {
        //GameObject buildings = (GameObject)Instantiate(Resources.Load("Prefabs/Map Base/P1"));
        //buildings.transform.parent = GameObject.Find("Ground").transform;
        //buildings.transform.localPosition = new Vector3(-4f,0f,4f);
        
        for (int i = 0; i < 8; i++)
        {
            GameObject buildings = null;
            int a = Random.Range(1, 4);
            if (a == 1)
            {
                buildings = (GameObject)Instantiate(Resources.Load("Prefabs/Map Base/P1"));
            }
            if ( a == 2)
            {
                buildings = (GameObject)Instantiate(Resources.Load("Prefabs/Map Base/P2"));
            }
            if ( a == 3)
            {
                buildings = (GameObject)Instantiate(Resources.Load("Prefabs/Map Base/P3"));
            }
            
            buildings.transform.parent = GameObject.Find("Ground").transform;

            if ( i < 3)
            {
                buildings.transform.localPosition = new Vector3(-4f + i * 4f,0f,4f);
            }
            if ( i == 3 || i == 4)
            {
                buildings.transform.localPosition = new Vector3(-4f + (i - 3) * 8f,0f,0f);
            }
            if ( i > 4)
            {
                buildings.transform.localPosition = new Vector3(-4f + (i - 5) * 4f,0f,-4f);
            }
        }
        
    }

    // Update is called once per frame
    void Update () 
    {

    }
}