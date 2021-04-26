using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Enemy;//NavMeshAgentをget
    public GameObject Target;//目的地
    // Start is called before the first frame update
    public float FindDis;//探す範囲
    public Transform[] directPoints;//移動範囲設定する点
    private int index = 0;//循環用記録変数
    public float stopTime = 3f;//停止時間
    private float timer = 0;
    private float a;
    void Awake()
    {
        //Enemy = gameObject.GetComponent<NavMeshAgent>();
        Enemy = GetComponent<NavMeshAgent>();
        Enemy.destination = directPoints[index].position;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position,Target.transform.position);//enemyと目的地の距離


    if (Enemy.remainingDistance < 2.0f)
    {


        timer += Time.deltaTime;

        if(timer >= stopTime)
        {
            Debug.Log("123");
            index++;
            index %= 4;
            timer = 0;
            Enemy.destination = directPoints[index].position;

        }
    }

        if(dis <= FindDis)//目的地は探す範囲内
        {
            if(gameObject.tag == "Dog")
            {
                if(Target != null)//目的地が存在する場合
                {
                    Enemy.destination = Target.transform.position;//目的地へ移動する
                }

            }

        }
        if(dis >= FindDis)
        {
            Debug.Log("123");
        }
    }
}
