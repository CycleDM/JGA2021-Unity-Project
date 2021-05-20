using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSuction : MonoBehaviour
{
    // プレイヤークラスの取得
    private PlayerController playerController;
    private GameObject Axis;
    private GameObject playerObj = null;
    private Vector3 playerPos;
    private Vector3 junkPos;

    // 吸収速度
    private float moveVelocity;

    private GameObject cleanerObj;

    private bool isColActive = false;

    [Header("ガラクタのレベル")]
    [SerializeField] private int junkLv;

    [Header("経験値")]
    [SerializeField] private int junkPoint;

    private int frameMax;
    private int frameCnt = 0;

    //private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        if(playerObj != null) playerController = playerObj.GetComponent<PlayerController>();

        Axis = GameObject.FindWithTag("Axis");

        playerPos = playerObj.transform.position;
        junkPos = transform.position;

        cleanerObj = GameObject.FindWithTag("Cleaner");

        isColActive = false;

        switch(junkLv){
            case 1:
            frameMax = 0;
            moveVelocity = 0.1f;
            break;

            case 2:
            frameMax = 30;
            moveVelocity = 0.1f;
            break;

            case 3:
            frameMax = 60*2;
            moveVelocity = 0.1f;
            break;

            case 4:
            frameMax = 60*3;
            moveVelocity = 0.1f;
            break;

            case 5:
            frameMax = 60*4;
            moveVelocity = 0.1f;
            break;

            case 6:
            frameMax = 60*5;
            moveVelocity = 0.1f;
            break;

            case 7:
            frameMax = 60*6;
            moveVelocity = 0.01f;
            break;

            case 8:
            frameMax = 60*7;
            moveVelocity = 0.01f;
            break;

            case 9:
            frameMax = 60*8;
            moveVelocity = 0.01f;
            break;

            default:break;
        }

       // moveVelocity = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        // true
        if(playerController.GetSuction() && isColActive)
        {
            frameCnt++;
            Vibrate();

            if(frameCnt >= frameMax)
            {
                frameCnt = frameMax;

                if(junkLv < 7)
                {
                    // 回転 
                    // lv7以下のみ。scaleがでかいと他のオブジェクトを吹っ飛ばしてしまうため
                    int randRot = 30;
                    transform.Rotate(new Vector3(Random.Range(randRot * -1, randRot * 1), Random.Range(randRot * -1, randRot * 1), Random.Range(randRot * -1, randRot * 1))); 
                }

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
        if(col.gameObject.CompareTag("Cleaner") && junkLv <= playerController.GetAbilityLV())
        {
            Debug.Log("Cleaner hit");
            isColActive = true;
        }
    }
    // 吸い込み判定(false)
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Cleaner") && junkLv <= playerController.GetAbilityLV())
        {
            Debug.Log("Cleaner not hit");
            isColActive = false;
        }
    }

    // 吸い込み後の処理 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")
          && junkLv <= playerController.GetAbilityLV()
          && playerController.GetSuction()
          && frameCnt >= frameMax)
        {
            // ガラクタを破壊
            playerController.SetAbilityLV(junkPoint);
            //Debug.Log("Destroy : cube");
            Axis.GetComponent<RectTransform>().Rotate(0, 0, junkPoint * 0.9f);
            Destroy(this.gameObject);
        }
    }
    private void Vibrate()
    {
        float velocity;
        if(junkLv < 7)
        {
            velocity = 0.005f;
        }
        else
        {
            velocity = 0.01f;
        }

        float value1 = Random.Range(velocity * -1.0f, velocity * 1.0f);
        float value2 = Random.Range(velocity * -1.0f, velocity * 1.0f);

        Vector3 pos = this.transform.localPosition;
        pos.x += value1;
        pos.z += value2;
        this.transform.localPosition = pos;
    }

    public int GetJunkPoints()
    {
        return junkPoint;
    }

    public void ResetGaugeRot()
    {
        Axis.GetComponent<RectTransform>().Rotate(0,0,-Axis.GetComponent<RectTransform>().eulerAngles.z);
    }

}
