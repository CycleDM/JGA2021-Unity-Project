using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerAbility : MonoBehaviour
{
    [SerializeField] private Text tLv;

    private PlayerController playerController;
    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーのタグ取得
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        tLv.text = string.Format("{0}" , playerController.GetAbilityLV());
    }



}
