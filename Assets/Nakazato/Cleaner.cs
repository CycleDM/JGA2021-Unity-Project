using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{

    [SerializeField] private bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Junk")
        { 
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public bool GetActive()
    {
        return isActive;
    }
}
