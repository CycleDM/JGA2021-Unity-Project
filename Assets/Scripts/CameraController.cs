using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject playerObj;
    private PlayerController playerController;
    private Vector3 playerPos;

    void Start () {
        playerObj = GameObject.Find("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
    }
    
    void Update() {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += playerObj.transform.position - playerPos;
        playerPos = playerObj.transform.position;
    
        if(playerController.GetAimFrag())
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 500f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * 500f);
        }
        else{ // 通常時
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            //float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 500f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            //transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 500f);
        }
    } 




//    [SerializeField] private GameObject followObject = null;    // プレイヤーオブジェクト
//    private Vector3 lookPos = Vector3.zero;                     // 実際にカメラに向ける座標
//
//    [SerializeField] private float lookPlayDistance = 0.3f;     // 視点の遊び
//    [SerializeField] private float followSmooth = 4.0f;         // 追いかけるときの速度
//
//    [SerializeField] private float cameraDistance = 2.5f;       // 視点からカメラまでの距離
//    [SerializeField] private float cameraHeight = 1.0f;         // デフォルトのカメラの高さ
//    private float currentCameraHeight = 1.0f;                   // 現在のカメラの高さ
//
//    [SerializeField] private float cameraPlayDiatance = 0.3f;   // 視点からカメラまでの距離の遊び
//    [SerializeField] private float leaveSmooth = 20.0f;         // 離れるときの速度
//
//    [SerializeField] private float cameraHeightMin = 0.1f;      // カメラの最低の高さ
//    [SerializeField] private float cameraHeightMax = 3.0f;      // カメラの最大の高さ
//
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        followObject = GameObject.FindWithTag("Player");
//    }
//
//
//    void UpdateLookPosition()
//    {
//        // 目標の視点と現在の視点の距離を求める
//        Vector3 vec = followObject.transform.position - lookPos;
//        float distance = vec.magnitude;
//
//        if (distance > lookPlayDistance)
//        {   // 遊びの距離を超えていたら目標の視点に近づける
//            float move_distance = (distance - lookPlayDistance) * (Time.deltaTime * followSmooth);
//            lookPos += vec.normalized * move_distance;
//        }
//    }
//
//    void UpdateCameraPosition()
//    {
//        // XZ平面におけるカメラと視点の距離を取得する
//        Vector3 xz_vec = followObject.transform.position - transform.position;
//        xz_vec.y = 0;
//        float distance = xz_vec.magnitude;
//
//        // カメラの移動距離を求める
//        float move_distance = 0;
//        if (distance > cameraDistance + cameraPlayDiatance)
//        {   
//            // カメラが遊びを超えて離れたら追いかける
//            move_distance = distance - (cameraDistance + cameraPlayDiatance);
//            move_distance *= Time.deltaTime * followSmooth;
//        }
//        else if (distance < cameraDistance - cameraPlayDiatance)
//        {   
//            // カメラが遊びを超えて近づいたら離れる
//            move_distance = distance - (cameraDistance - cameraPlayDiatance);
//            move_distance *= Time.deltaTime * leaveSmooth;
//        }
//
//　　　　// 新しいカメラの位置を求める
//        Vector3 camera_pos = transform.position + (xz_vec.normalized * move_distance);
//	
//	    // 高さは常に現在の視点からの一定の高さを維持する
//        camera_pos.y = lookPos.y + currentCameraHeight;
//
//        transform.position = camera_pos;
//    }
//
//    void FixedUpdate()
//    {
//        if(followObject == null) return;
//
//        UpdateLookPosition();
//        UpdateCameraPosition();
//
//        transform.LookAt(lookPos);
//    }
//
//    public void Roll(float x, float y)
//    {
//        // 移動前の距離を保存する
//        float prev_distance = Vector3.Distance(followObject.transform.position, transform.position);
//        Vector3 pos = transform.position;
//
//        // 横に移動する
//        pos += transform.right * x;
//
//        // 縦に移動する
//        currentCameraHeight = Mathf.Clamp(currentCameraHeight + y, cameraHeightMin, cameraHeightMax);
//        pos.y = lookPos.y + currentCameraHeight;
//
//        // 移動後の距離を取得する
//        float after_distance = Vector3.Distance(followObject.transform.position, pos);
//
//        // 視点を対象に向けて近づける（遊びをなくす）
//        lookPos = Vector3.Lerp(lookPos, followObject.transform.position, 0.1f);
//
//        // カメラの更新
//        transform.position = pos;
//        transform.LookAt(lookPos);
//
//        // 平行移動により若干距離が変わるので補正する
//        transform.position += transform.forward * (after_distance - prev_distance);
//    }
//
//    public void Reset(float rate = 1)
//    {
//        // 視点対象に近づける
//        lookPos = Vector3.Lerp(lookPos, followObject.transform.position, rate);
//
//        // 高さをデフォルトに近づける
//        currentCameraHeight = Mathf.Lerp(currentCameraHeight, cameraHeight, rate);
//
//        // カメラを基本位置に近づける
//        Vector3 pos_goal = followObject.transform.position;
//        pos_goal -= followObject.transform.forward * cameraDistance;
//        pos_goal.y = followObject.transform.position.y + currentCameraHeight;
//        transform.position = Vector3.Lerp(transform.position, pos_goal, rate);
//
//        // 視線を更新する
//        transform.LookAt(lookPos);
//    }
}
