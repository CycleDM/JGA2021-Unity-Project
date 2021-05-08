using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private GameObject targetObj;
    private Vector3 targetPos;

    private PlayerController playerController;

    // フィールドを追加して、積算回転角を別途覚えておけるようにしておく
    private float angleH;
    private float angleV;

    void Start()
    {
        //カーソルをロックする
        Cursor.lockState = CursorLockMode.Locked;
        //カーソルを見えなくする
        Cursor.visible = false;

        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        playerController = targetObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        float inputX;
        float inputY;

        if(playerController.GetAimFrag()) // aim
        { 
    
        }
        else // 通常時
        {
            // マウスの移動量
            inputX = Input.GetAxis("Mouse X");
            inputY = Input.GetAxis("Mouse Y");

            SetCameraUpdate(inputX,inputY);
        }
    }

    private void SetCameraUpdate(float x,float y)
    {
        // マウス移動量から求めた水平・垂直回転角
        float deltaAngleH = x * Time.deltaTime * 500f;
        float deltaAngleV = -y * Time.deltaTime * 500f;

        // 角度を積算する
        angleV += deltaAngleV;

        // 積算角度を制限内にクランプする
        float clampedAngleV = Mathf.Clamp(angleV, -30, 30);

        // クランプ前の積算角からクランプ後の積算角を引いて、どれだけ制限範囲を超えたかを求める
        float overshootV = angleV - clampedAngleV;

        // 角度差分だけ回転量を調整
        deltaAngleV -= overshootV;
        angleV = clampedAngleV;

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, deltaAngleH);

        // カメラの垂直移動
        transform.RotateAround(targetPos, transform.right, deltaAngleV);
    }

}
