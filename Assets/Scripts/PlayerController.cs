using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSpeed = 5;
    public float jumpVelocity = 5;

    private bool isOnGround = true;

    private bool isAbsorption = false; // 吸収

    private float horizontal = 0f;
    private float vertical = 0f;


    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        isAbsorption = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        //rig.transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        //rig.transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
 
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

        // 吸い込み
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Press.R true");
            isAbsorption = true;
        }
        else
        {
            Debug.Log("Press.R false");
            isAbsorption = false;
        }
    }

    void FixedUpdate() {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;
    
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rig.velocity = moveForward * moveSpeed + new Vector3(0, rig.velocity.y, 0);
    
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }

    public bool GetAbsorption()
    {
        return isAbsorption;
    }
}
