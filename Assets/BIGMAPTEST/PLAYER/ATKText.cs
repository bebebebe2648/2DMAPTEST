using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATKText : MonoBehaviour
{
    
    PlayerStatus PS;

    public int pATK = 5;  //ATKの初期値

    // Use this for initialization
    void Awake ()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GetComponent<Text>().text = "ATK :" + pATK + "/" + PS.PMAXATK;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //GameManagementからプレイヤーの現在のATKの状態を新規ATKとして代入
        int NEWSATK = PS.PATKING;
        PS.SaveATK = NEWSATK;
        int NEWSMATK = PS.PMAXATK;
        PS.SaveMATK = NEWSMATK;
        //新規ATKを表示
        GetComponent<Text>().text = "ATK: " + NEWSATK + "/" + NEWSMATK;
    }
    
}