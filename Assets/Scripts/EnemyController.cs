using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Enemy;//NavMeshAgentをget
    [Header("プレイヤーを設定")]
    [Header("敵のスピードはnav mesh agentのなかで設定")]
    public GameObject Player;//目的地
    // Start is called before the first frame update
    private Rigidbody PlayerRb;

    [Header("移動する範囲配列")]
    public Transform[] directPoints;//移動範囲設定する点
    private int index = 0;  //循環用記録変数
    [Header("どのぐらい時間を待って次の場所へ移動")]
    [Header("目的地を到着した後、")]
    public float stopTime = 3f;//停止時間
    private float timer = 0;

    private float dis;//enemyと目的地の距離
    [Header("探す範囲の大きさ")]
    public float FindDis;//探す範囲
    [Header("プレイヤーからどこまで逃げる範囲")]
    public float EscapeDis;//逃げる範囲
    private bool Escape=false;
    private bool collide = false;

        private float m_force;


    private Vector3 direction = new Vector3();//敵とプレイヤーのベクトル

    void Awake()
    {
        PlayerRb = Player.GetComponent<Rigidbody>();
        Enemy = GetComponent<NavMeshAgent>();
        Enemy.destination = directPoints[index].position;
        m_force = Enemy.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dis = Vector3.Distance(transform.position,Player.transform.position);

    if (Enemy.remainingDistance < 2.0f)
    {
        timer += Time.deltaTime;
        if(timer >= stopTime)
        {
            index++;
            index %=directPoints.Length;
            timer = 0;
            Enemy.destination = directPoints[index].position;
        }
    }

        //敵からプレイヤーのベクトルを設定
        direction = (Player.transform.position-transform.position).normalized;
        direction.y=0;

        //逃げる、弾き飛ばすの速度
        direction= direction * m_force*5.0f;

        if(dis <= FindDis)//目的地は探す範囲内
        {
            if(gameObject.tag == "Dog")
            {
                if(Player != null)//目的地が存在する場合
                {
                    Enemy.destination = Player.transform.position;//目的地へ移動する
                }
            }

            if(gameObject.tag == "Cat")
            {
                Escape = true;
            }

        }
        if(dis <= EscapeDis)
        {
            if(gameObject.tag == "Cat")
            {
                if(Escape)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.LookRotation(( transform.position- Player.transform.position )),
                            m_force* 3* Time.deltaTime);
                    transform.position -= (direction*Time.deltaTime);//プレイヤーから逃げる
                }
            }
            if(gameObject.tag == "Dog")
            {
                if(collide)
                {
                PlayerRb.transform.position +=(direction*Time.deltaTime);//プレイヤーを弾き飛ばすパワー
                }
            }
        }
        if(dis>=EscapeDis)
        {
            Escape = false;
            collide = false;
        }
    }


    void OnCollisionEnter(Collision ctl)
    {
        if(gameObject.tag == "Dog")
            {
        collide =true;
        }
    }
}

