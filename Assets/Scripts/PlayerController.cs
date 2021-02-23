using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSpeed = 5;
    //public float jumpVelocity = 5;
    //private bool isOnGround = true;

    public Transform rotationTarget;
    public float rotationRadius;

    private float angle;

    private Vector3 moveDir;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();

        moveDir = Vector3.right;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        //rig.transform.Translate(Vector3.forward * horizontal * moveSpeed * Time.deltaTime);
        
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
