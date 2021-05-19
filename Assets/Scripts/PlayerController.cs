using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSetSpeed = 10;
    private float moveSpeed;
    public float jumpVelocity = 5;

    private bool isOnGround = true;

    private bool isSuction = false; // 吸収

    private float horizontal = 0f;
    private float vertical = 0f;
    private bool isAim = false;

    public SceneChanger sceneChanger;

    
    private int playerLv; // =1
    private int abilityScore;


    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        isSuction = false;
        isAim = false;

        playerLv = 1;
        abilityScore = 0;
        Cursor.lockState = CursorLockMode.Locked; //カーソルを消す

        moveSpeed = moveSetSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
       
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

//        // Jump
//        if (Input.GetButtonDown("Jump"))
//        {
//            if (isOnGround)
//            {
//                rig.velocity += new Vector3(0, jumpVelocity, 0);
//                //rig.AddForce(Vector3.up * 300);
//                isOnGround = false;
//            }
//        }

        // 吸引
        if (Input.GetMouseButton(0))
        {
            isSuction = true;
        }
        else
        {
            isSuction = false;
        }

        if(abilityScore > 100)
        {
            abilityScore = 0;
            playerLv++;
            if(playerLv > 9)playerLv = 9;
        }


        // aim
        if (Input.GetMouseButtonDown(1))
        {
            isAim = true;
        }
        else
        {
            isAim = false;
        }

         if (Input.GetKey(KeyCode.Z))
        {
            sceneChanger.SetSceneChange(true);
            Cursor.lockState = CursorLockMode.None;
        }

        // 速度調整
        if(!isSuction && !isAim)
        {
            moveSpeed = moveSetSpeed;  
        }
        else
        {
            if(isSuction)
            {
                moveSpeed = moveSetSpeed * 0.5f; 
            }

            if(isAim)
            {
                moveSpeed = 0;
            }
        }
    }

    void FixedUpdate() 
    {
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

        //AIM時にカメラの向きにキャラが向くように
        if(GetAimFrag())
        {
            Quaternion Q;   
            Q = Quaternion.LookRotation(Camera.main.transform.forward);
            Q.x = 0;
            Q.z = 0;
            transform.rotation = Q;
           
        }
        
    }


    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }

    public bool GetSuction()
    {
        return isSuction;
    }

    public bool GetAimFrag()
    {
        return isAim;
    }

    public int GetAbilityLV()
    {
        return playerLv;
    }

    public void SetAbilityLV(int i)
    {
        abilityScore += i;
    }
}
