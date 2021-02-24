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

    private Cleaner cleaner;
    [SerializeField] private GameObject cleanerObj;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
        junkPos = transform.position;

        cleanerObj = GameObject.FindWithTag("Cleaner");
        cleaner = cleanerObj.GetComponent<Cleaner>();
    }

    // Update is called once per frame
    void Update()
    {
        // true
        if(playerController.GetAbsorption() && cleaner.GetActive())
        {
            //playerPos = playerObj.transform.position;
            //junkPos = transform.position;
    
            //if (playerPos.x > junkPos.x)
            //{
            //    junkPos.x = junkPos.x + moveVelocity;
            //}
            //else if (playerPos.x < junkPos.x)
            //{
            //    junkPos.x = junkPos.x - moveVelocity;
            //}
    
            //if (playerPos.y > junkPos.y)
            //{
            //    junkPos.y = junkPos.y + moveVelocity;
            //}
            //else if (playerPos.y < junkPos.y)
            //{
            //    junkPos.y = junkPos.y - moveVelocity;
            //}

            //if (playerPos.z > junkPos.z)
            //{
            //    junkPos.z = junkPos.z + moveVelocity;
            //}
            //else if (playerPos.z < junkPos.z)
            //{
            //    junkPos.z = junkPos.z - moveVelocity;
            //}
    
            //transform.position = junkPos;


            playerPos = playerObj.transform.position;
            junkPos = transform.position;
    
            junkPos.x += (playerPos.x - junkPos.x) * moveVelocity;
            junkPos.y += (playerPos.y - junkPos.y) * moveVelocity;
            junkPos.z += (playerPos.z - junkPos.z) * moveVelocity;
            transform.position = junkPos;
        }
    }

    // 吸い込み後の処理 
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && playerController.GetAbsorption())
        { // ガラクタを破壊
            Destroy(this.gameObject);
        }
    }
    
}
