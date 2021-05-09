using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private GameObject targetObj;
    private Vector3 targetPos;

    private PlayerController playerController;

    private float angleH;
    private float angleV;

    private GameObject aimObj;
    private GameObject startObj;


    void Start()
    {
        //カーソルをロックする
        Cursor.lockState = CursorLockMode.Locked;
        //カーソルを見えなくする
        Cursor.visible = false;

        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        playerController = targetObj.GetComponent<PlayerController>();

        aimObj = GameObject.Find("Pivot");
        startObj = GameObject.Find("CameraPos");
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");
        //SetCameraUpdate(inputX,inputY);

        if(playerController.GetAimFrag()) // aim
        {
            ///
            //transform.position = Vector3.Lerp(transform.position, aimObj.transform.position, Time.deltaTime * 100.0f);
        }
        else // 通常時
        {
            SetCameraUpdate(inputX,inputY);
            //transform.position = Vector3.Lerp(transform.position, startObj.transform.position, Time.deltaTime * 100.0f);
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
