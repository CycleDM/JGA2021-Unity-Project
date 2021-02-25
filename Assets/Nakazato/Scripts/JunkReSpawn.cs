using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkReSpawn : MonoBehaviour
{
    // ガラクタ配列
	[SerializeField] GameObject[] junks;
	// ガラクタが出現するまでの時間
	[SerializeField] float appearNextTime;
	// 出現するガラクタの数
	[SerializeField] int maxNumOfJunks;
	// 何個のガラクタを出現させたか（総数）
	private int numberOfJunks;
	// 待ち時間計測フィールド
	private float elapsedTime;
 
	// Use this for initialization
	void Start () {
		numberOfJunks = 0;
		elapsedTime = 0f;
	}

    // Update is called once per frame
    void Update () {
    	// 安全装置
    	if (numberOfJunks >= maxNumOfJunks) 
        {
    		return;
    	}
    	// 経過時間加算
    	elapsedTime += Time.deltaTime;
    
    	// 経過時間が経ったら
    	if (elapsedTime > appearNextTime) 
        {
    		elapsedTime = 0f;
    		AppearJunk ();
    	}
    }

    // スポーン
    void AppearJunk() {
    	//　出現させるガラクタをランダムに選ぶ
    	var randomValue = Random.Range (0, junks.Length);
    	//　ガラクタの向きをランダムに決定
    	var randomRotationY = Random.value * 360f;
    
    	GameObject.Instantiate (junks[randomValue], transform.position, Quaternion.Euler (0f, randomRotationY, 0f));
    
    	numberOfJunks++;
    	elapsedTime = 0f;
    }
}
