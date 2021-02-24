using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public float moveSpeed = 5;
    public float jumpVelocity = 5;

    private bool isOnGround = true;

    private bool isAbsorption = false; // 吸収
    private Vector3 playerPos; //プレイヤーのポジション

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        playerPos = GetComponent<Transform>().position;
        isAbsorption = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        rig.transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);

        rig.velocity = new Vector3(horizontal * moveSpeed, 0, vertical * moveSpeed); //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動

        Vector3 diff = transform.position - playerPos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得

        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        playerPos = transform.position; //プレイヤーの位置を更新

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (isOnGround)
            {
                rig.velocity += new Vector3(0, jumpVelocity, 0);
                //rig.AddForce(Vector3.up * 300);
                isOnGround = false;
            }
        }

        // 吸い込み
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Press.R true");
            isAbsorption = true;
        }
        else
        {
            Debug.Log("Press.R false");
            isAbsorption = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }

    public bool GetAbsorption()
    {
        return isAbsorption;
    }
}
