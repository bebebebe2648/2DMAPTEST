using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPText : MonoBehaviour
{
    
    PlayerStatus PS;

    //EXPの初期値
    public int pEXP = 0;
    //必要経験値
    public int NEEDEXP = 10;
    public int SaveNEEDEXP;
    
    //レベルアップフラグ
    public bool LvUPFlag;
    //メッセージフラグ
    public bool LvUPMSFlag;

    // Use this for initialization
    void Awake()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GetComponent<Text>().text = "EXP :" + pEXP;
    }

    // Update is called once per frame
    void Update()
    {
        //GameManagementからプレイヤーの現在のEXPの状態を新規EXPとして代入
        int NEWSEXP = PS.SUMEXP;
        PS.SaveEXP = NEWSEXP;
        //新規EXPを表示
        GetComponent<Text>().text = "EXP: " + NEWSEXP + "/" + NEEDEXP;

        //必要経験値を累計経験値
        if (NEWSEXP >= NEEDEXP)
        {
            LvUPFlag = true;
            LvUPMSFlag = true;
            int EXP = NEEDEXP + (10 * PS.PNOWLv);
            NEEDEXP = EXP;
            SaveNEEDEXP = EXP;
            //レベルアップでのステータスアップ
            PS.LEVELUP();
        }
    }
    
}