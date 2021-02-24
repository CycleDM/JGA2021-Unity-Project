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
    [SerializeField] private float moveVelocity = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
        junkPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // true
        if(playerController.GetAbsorption())
        {
            playerPos = playerObj.transform.position;
            junkPos = transform.position;
    
            junkPos.x += (playerPos.x - junkPos.x) * moveVelocity;
            junkPos.y += (playerPos.y - junkPos.y) * moveVelocity;
            junkPos.z += (playerPos.z - junkPos.z) * moveVelocity;
            transform.position = junkPos;
        }
    }
}
