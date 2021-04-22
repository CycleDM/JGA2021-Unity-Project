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

    void Start()
    {
        Enemy = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position,Target.transform.position);//enemyと目的地の距離
        if(Target != null)//目的地が存在する場合
        {
            Enemy.destination = Target.transform.position;//目的地へ移動する
        }
        if(dis <= FindDis)//目的地は探す範囲内
        {
            Enemy.Stop();//移動停止
        }
        if(dis >= FindDis)
        {
            Debug.Log("123");
        }
    }
}
