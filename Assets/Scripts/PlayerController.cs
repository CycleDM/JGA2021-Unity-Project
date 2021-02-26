using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSpeed = 5;
    public float rotateSpeed = 30f;
    public float jumpVelocity = 5;
    private bool isOnGround = true;
    public Transform pPickUp;
    private GameObject PickUp;
    bool onPickUp = false;
    string oldTag;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(onPickUp)
        {
            PickUp.gameObject.SetActive(true);
            PickUp.GetComponent<Transform>().position = pPickUp.GetComponent<Transform>().position;
        }
        if(Input.GetKey(KeyCode.G)&&PickUp.gameObject.tag != "rubbish")
        {
            onPickUp = false;
            PickUp.gameObject.GetComponent<Collider>().enabled = true;
            if(PickUp.gameObject.tag != "resource")
            {
                PickUp.gameObject.tag = oldTag;
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.transform.Translate(new Vector3(0,0,vertical) * moveSpeed * Time.deltaTime);
        rig.transform.Rotate(new Vector3(0,horizontal,0) * rotateSpeed * Time.deltaTime);
        rig.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;

        if((other.gameObject.tag == "rubbish" || other.gameObject.tag == "resource")&&(!onPickUp))
        {
           // if (Input.GetKey(KeyCode.Space))
            {
                oldTag = other.gameObject.tag;
                //other.gameObject.GetComponent<Collider>().enabled = false;
                other.gameObject.tag = "pickup";
                other.gameObject.SetActive(false);
                onPickUp = true;
                PickUp = other.gameObject;
            }
        }
    }
}
