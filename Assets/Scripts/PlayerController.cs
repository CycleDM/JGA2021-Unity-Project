using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    //public float jumpVelocity = 5;
    //private bool isOnGround = true;

    public GameObject rotationTarget;

    private float radius;
    private Vector3 center;

    // Start is called before the first frame update
    private void Start()
    {
        center = new Vector3(rotationTarget.transform.position.x, this.transform.position.y, rotationTarget.transform.position.z);
        radius = Vector3.Distance(center, this.transform.position);
    }

    // Update is called once per frame
    private void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    private void FixedUpdate()
    {
        center = new Vector3(rotationTarget.transform.position.x, this.transform.position.y, rotationTarget.transform.position.z);
        Vector3 dir = this.transform.position - center;
        this.transform.right = dir;
        
        float distance = Vector3.Distance(center, this.transform.position);
        this.transform.position = center + dir.normalized * radius;

        float horizontal = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * horizontal * moveSpeed * Time.deltaTime);

        // Jump
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (isOnGround)
        //    {
        //        rig.velocity += new Vector3(0, jumpVelocity, 0);
        //        //rig.AddForce(Vector3.up * 300);
        //        isOnGround = false;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        //isOnGround = true;
    }
}