using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject playerObj;
    private PlayerController playerController;
    private Vector3 playerPos;

    [Header("アングルの制限")]
    [SerializeField]private float viewAngle;

    void Start () {
        playerObj = GameObject.Find("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
    }
    
    void Update() {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += playerObj.transform.position - playerPos;
        playerPos = playerObj.transform.position;

        float mouseInputX;
        float mouseInputY;
    
        if(playerController.GetAimFrag())
        {
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 500f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * 500f);
        }
        else // 通常時
        {
            // マウスの移動量
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 500f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * 500f);
        }

        limitRotate(mouseInputX, mouseInputY, viewAngle);
    } 

    void limitRotate(float _inputX,float _inputY,float limit)
    {
        float maxLimit = limit, minLimit = 360 - maxLimit;
        //X軸回転
        var localAngle = transform.localEulerAngles;
        localAngle.x += _inputY;
        if (localAngle.x > maxLimit && localAngle.x < 180)
        {
            localAngle.x = maxLimit;
        }
        if (localAngle.x < minLimit && localAngle.x > 180)
        {
            localAngle.x = minLimit;
        }
        transform.localEulerAngles = localAngle;
        //Y軸回転
        var angle = transform.eulerAngles;
        angle.y += _inputX;
        transform.eulerAngles = angle;
    }

}
