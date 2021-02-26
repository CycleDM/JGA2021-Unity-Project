using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float fallingSpeed = 1;

    private int randomColor;

    // Start is called before the first frame update
    private void Start()
    {
        if (this.gameObject.tag == "PT Safty Ball")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (this.gameObject.tag == "PT Dangerous Ball")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.Translate(-Vector3.up * fallingSpeed * Time.deltaTime);
        if (this.transform.position.y <= -1)
        {
            Destroy(this.gameObject);
        }
    }
}
