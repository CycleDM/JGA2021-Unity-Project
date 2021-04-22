using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerPT01 : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpVelocity = 5;
    private bool isOnGround = true;
    private Rigidbody rig;

    // Player Score
    private static int currentScore = 0;
    public static int goalScore = 10;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate() 
    {
        // Jump
        if (Input.GetButton("Jump"))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PT Safty Ball")
        {
            Destroy(other.gameObject);
            currentScore++;
            if (currentScore >= 10)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (other.gameObject.tag == "PT Dangerous Ball")
        {
            Destroy(other.gameObject);
            currentScore-=2;
            if (currentScore < 0) currentScore = 0;
        }
    }

    public static int GetPlayerScore()
    {
        return currentScore;
    }
    public static int GetPlayerMaxGoal()
    {
        return goalScore;
    }
}
