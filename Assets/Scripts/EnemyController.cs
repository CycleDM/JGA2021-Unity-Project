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
    public Transform[] directPoints;//��ư�ϰ����ꤹ����
    private int index = 0;//�۴��ѵ�Ͽ�ѿ�
    public float stopTime = 3f;//��߻���
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
        float dis = Vector3.Distance(transform.position,Target.transform.position);//enemy����Ū�Ϥε�Υ


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

        if(dis <= FindDis)//��Ū�Ϥ�õ���ϰ���
        {
            if(gameObject.tag == "Dog")
            {
                if(Target != null)//��Ū�Ϥ�¸�ߤ�����
                {
                    Enemy.destination = Target.transform.position;//��Ū�Ϥذ�ư����
                }

            }

        }
        if(dis >= FindDis)
        {
            Debug.Log("123");
        }
    }
}
