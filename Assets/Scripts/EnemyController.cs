using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Enemy;//NavMeshAgent��get
    public GameObject Target;//��Ū��
    // Start is called before the first frame update
     public float FindDis;//õ���ϰ�

    void Start()
    {
        Enemy = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position,Target.transform.position);//enemy����Ū�Ϥε�Υ
        if(Target != null)//��Ū�Ϥ�¸�ߤ�����
        {
            Enemy.destination = Target.transform.position;//��Ū�Ϥذ�ư����
        }
        if(dis <= FindDis)//��Ū�Ϥ�õ���ϰ���
        {
            Enemy.Stop();//��ư���
        }
        if(dis >= FindDis)
        {
            Debug.Log("123");
        }
    }
}
