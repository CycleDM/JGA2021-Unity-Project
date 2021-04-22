using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject playerObj;
    private PlayerController playerController;
    private Vector3 playerPos;

    public bool xInv = true;
    public bool yInv = false;

    public int maxCamLimit = 60;
    public int minCamLimit = -30;

    public float sensi = 500.0f;
    bool Camfrag = false;
 
    void Start () {
        playerObj = GameObject.Find("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
    }
    
    void Update() {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += playerObj.transform.position - playerPos;
        playerPos = playerObj.transform.position;

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        // targetの位置のY軸を中心に、回転（公転）する
        if(xInv == true)
        {
           transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * sensi);
        }
        else { 
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * sensi * -1);
        }

        // カメラの垂直移動
        Quaternion oldQ = transform.rotation;
        Vector3 oldPos = transform.position;
        if(yInv == true) 
        {
              transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * sensi);
        }
        else {
               transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * sensi * -1);
        }

        //カメラ角度制限
        var V = transform.localEulerAngles;
        if(V.x > maxCamLimit)
        {
            transform.rotation = oldQ;
            transform.position = oldPos;
        }
         if(V.x < minCamLimit)
        {
            transform.rotation = oldQ;
            transform.position = oldPos;
        }

        //エイム時のカメラを寄せる
        if(playerController.GetAimFrag() == true & Camfrag == false)
        {
           Camera.main.transform.position += Camera.main.transform.forward * 3;
            Camfrag = true;
        }
        else if(playerController.GetAimFrag() == false & Camfrag == true){
            Camera.main.transform.position += -Camera.main.transform.forward * 3;
            Camfrag = false;
        }
    } 

}
