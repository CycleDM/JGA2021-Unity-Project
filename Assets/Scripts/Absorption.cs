using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum VibrateType
{
    VERTICAL,
    HORIZONTAL
}
public class Absorption : MonoBehaviour
{
    // プレイヤークラスの取得
    private PlayerController playerController;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private Vector3 playerPos;
    [SerializeField] private Vector3 junkPos;
    [SerializeField] private Vector3 junkScale;

    // 吸収速度
    [SerializeField] private float moveVelocity;

    [SerializeField] private GameObject cleanerObj;

    [SerializeField] private bool isColActive = false;


    [SerializeField] private int junkSize;
    [SerializeField] private int junkPoint;

    private int frameMax;
    private int frameCnt = 0;


/////
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float maxAngle = 0.1f;

    float startTime;
    Quaternion startRotation;
/////
    [SerializeField] private VibrateType vibrateType;          //振動タイプ
    [Range(0, 1)] [SerializeField] private float vibrateRange; //振動幅
    [SerializeField] private float vibrateSpeed;               //振動速度
    private float initPosition;   //初期ポジション
    private float newPosition;    //新規ポジション
    private float minPosition;    //ポジションの下限
    private float maxPosition;    //ポジションの上限
    private bool directionToggle; //振動方向の切り替え用トグル(オフ：値が小さくなる方向へ オン：値が大きくなる方向へ)

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();

        playerPos = playerObj.transform.position;
        junkPos = transform.position;

        cleanerObj = GameObject.FindWithTag("Cleaner");

        isColActive = false;

        moveVelocity = 0.1f;

        switch(junkSize){
            case 1:
            frameMax = 0;
            break;

            case 2:
            frameMax = 30;
            break;

            case 3:
            frameMax = 60*2;
            break;

            case 4:
            frameMax = 60*3;
            break;

            case 5:
            frameMax = 60*4;
            break;

            case 6:
            frameMax = 60*5;
            break;

            case 7:
            frameMax = 60*6;
            break;

            case 8:
            frameMax = 60*7;
            break;

            case 9:
            frameMax = 60*8;
            break;

            default:break;
        }

        startTime = Time.time;
        startRotation = transform.rotation;

        //初期ポジションの設定を振動タイプ毎に分ける
        switch (this.vibrateType) {
            case VibrateType.VERTICAL:
                this.initPosition = transform.localPosition.y;
                break;
            case VibrateType.HORIZONTAL:
                this.initPosition = transform.localPosition.x;
                break;
        }

            this.newPosition = this.initPosition;
            this.minPosition = this.initPosition - this.vibrateRange;
            this.maxPosition = this.initPosition + this.vibrateRange;
            this.directionToggle = false;

    }

    // Update is called once per frame
    void Update()
    {
        // true
        if(playerController.GetAbsorption() && isColActive)
        {
            if(frameCnt <= frameMax)
            {
                frameCnt++;
                // ここでオブジェクトを震わせる
                Vibrate();

            }
            else if(frameCnt >= frameMax)
            {
                frameCnt = frameMax;
//                playerPos = playerObj.transform.position;
//                junkPos = transform.position;
//        
//                if (playerPos.x > junkPos.x)
//                {
//                    junkPos.x = junkPos.x + moveVelocity;
//                }
//                else if (playerPos.x < junkPos.x)
//                {
//                    junkPos.x = junkPos.x - moveVelocity;
//                }
//        
//                if (playerPos.y > junkPos.y)
//                {
//                    junkPos.y = junkPos.y + moveVelocity;
//                }
//                else if (playerPos.y < junkPos.y)
//                {
//                    junkPos.y = junkPos.y - moveVelocity;
//                }
//    
//                if (playerPos.z > junkPos.z)
//                {
//                    junkPos.z = junkPos.z + moveVelocity;
//                }
//                else if (playerPos.z < junkPos.z)
//                {
//                    junkPos.z = junkPos.z - moveVelocity;
//                }
//        
//                transform.position = junkPos;    
    
                playerPos = playerObj.transform.position;
                junkPos = transform.position;

                junkPos.x += (playerPos.x - junkPos.x) * moveVelocity;
                junkPos.y += (playerPos.y - junkPos.y) * moveVelocity;
                junkPos.z += (playerPos.z - junkPos.z) * moveVelocity;
                transform.position = junkPos;

            }
        }
    }


    // 吸い込み判定(true)
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Cleaner") && junkSize <= playerController.GetAbilityLV())
        {
            Debug.Log("Cleaner hit");
            isColActive = true;
        }
    }
    // 吸い込み判定(false)
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Cleaner") && junkSize <= playerController.GetAbilityLV())
        {
            Debug.Log("Cleaner not hit");
            isColActive = false;
        }
    }

    // 吸い込み後の処理 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")
          && junkSize <= playerController.GetAbilityLV()
          && playerController.GetAbsorption()
          && frameCnt >= frameMax)
        {
            // ガラクタを破壊
            playerController.SetAbilityLV(junkPoint);
            Debug.Log("Destroy : cube");
            Destroy(this.gameObject);
        }
    }
    private void Vibrate()
    {

        //ポジションが振動幅の範囲を超えた場合、振動方向を切り替える
        if (this.newPosition <= this.minPosition ||
            this.maxPosition <= this.newPosition) {
            this.directionToggle = !this.directionToggle;
        }

        //新規ポジションを設定
        this.newPosition = this.directionToggle ? 
            this.newPosition + (vibrateSpeed * Time.deltaTime) :
            this.newPosition - (vibrateSpeed * Time.deltaTime);
        this.newPosition = Mathf.Clamp (this.newPosition, this.minPosition, this.maxPosition);

        //新規ポジションを代入
        switch (this.vibrateType) {
            case VibrateType.VERTICAL:
                this.transform.localPosition = new Vector3 (0, this.newPosition, 0);
                break;
            case VibrateType.HORIZONTAL:
                this.transform.localPosition = new Vector3 (this.newPosition, 0, 0);
                break;
        }
    }

    public int GetJunkPoints()
    {
        return junkPoint;
    }

}
