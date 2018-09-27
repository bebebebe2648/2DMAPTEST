using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    
    PlayerStatus PS;

    public int pHP = 30;  //HPの初期値

    // Use this for initialization
    void Awake ()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GetComponent<Text>().text = "HP :" + pHP + "/" + PS.PMAXHP;
    }

    // Update is called once per frame
    void Update ()
    {
        //PlayerStatusからプレイヤーの現在のHPの状態を新規HPとして代入
        int NEWSHP = PS.PHPING;
        PS.SaveHP = NEWSHP;
        int NEWSMHP = PS.PMAXHP;
        PS.SaveMHP = NEWSMHP;
        //新規HPを表示
        GetComponent<Text>().text = "HP: " + NEWSHP + " / " + NEWSMHP;
    }
    
}