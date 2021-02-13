using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSpeed = 5;
    public float jumpVelocity = 5;

    private bool isOnGround = true;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        rig.transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (isOnGround)
            {
                rig.velocity += new Vector3(0, jumpVelocity, 0);
                //rig.AddForce(Vector3.up * 300);
                isOnGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
