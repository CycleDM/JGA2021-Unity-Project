using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
    // プレイヤークラスの取得
    private PlayerController playerController;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private Vector3 playerPos;
    [SerializeField] private Vector3 junkPos;

    // 吸収速度
    [SerializeField] private float moveVelocity = 0.005f;

    [SerializeField] private GameObject cleanerObj;


    [SerializeField] private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
        junkPos = transform.position;

        cleanerObj = GameObject.FindWithTag("Cleaner");

        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // true
        if(playerController.GetAbsorption() && isActive)
        {
            playerPos = playerObj.transform.position;
            junkPos = transform.position;
    
            if (playerPos.x > junkPos.x)
            {
                junkPos.x = junkPos.x + moveVelocity;
            }
            else if (playerPos.x < junkPos.x)
            {
                junkPos.x = junkPos.x - moveVelocity;
            }
    
            if (playerPos.y > junkPos.y)
            {
                junkPos.y = junkPos.y + moveVelocity;
            }
            else if (playerPos.y < junkPos.y)
            {
                junkPos.y = junkPos.y - moveVelocity;
            }

            if (playerPos.z > junkPos.z)
            {
                junkPos.z = junkPos.z + moveVelocity;
            }
            else if (playerPos.z < junkPos.z)
            {
                junkPos.z = junkPos.z - moveVelocity;
            }
    
            transform.position = junkPos;


           // playerPos = playerObj.transform.position;
           // junkPos = transform.position;
    //
           // junkPos.x += (playerPos.x - junkPos.x) * moveVelocity;
           // junkPos.y += (playerPos.y - junkPos.y) * moveVelocity;
           // junkPos.z += (playerPos.z - junkPos.z) * moveVelocity;
           // transform.position = junkPos;
        }
    }

    // 吸い込み判定
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Cleaner"))
        {
            Debug.Log("Cleaner hit");
            isActive = true;
        }
        else
        {
            Debug.Log("Cleaner not hit");
            isActive = false;
        }
    }

    // 吸い込み後の処理 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && playerController.GetAbsorption())
        { // ガラクタを破壊
            Debug.Log("Destroy : cube");
            Destroy(this.gameObject);
        }
    }

}
