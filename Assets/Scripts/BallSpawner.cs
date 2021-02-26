using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float timer = 5;
    private float _timer;

    public int safePercentage = 60;

    private bool isActive = true;

    // Start is called before the first frame update
    private void Start()
    {
        _timer = timer;
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            CreateBall();
            timer = _timer;
        }
    }

    private void CreateBall()
    {
        //if (!isActive) return;
        GameObject ball = GameObject.Instantiate(prefab, this.transform.position, this.transform.rotation);
        int rand = Random.Range(0, 100);
        if (rand < safePercentage)
        {
            ball.tag = "PT Safty Ball";
        }
        else
        {
            ball.tag = "PT Dangerous Ball";
        }
        isActive = false;
    }
}
