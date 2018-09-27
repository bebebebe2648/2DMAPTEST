using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPDText : MonoBehaviour
{
    
    PlayerStatus PS;

    public int pSPD = 5;  //SPDの初期値

	// Use this for initialization
	void Awake ()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GetComponent<Text>().text = "SPD :" + pSPD + "/" + PS.PMAXSPD;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //GameManagementからプレイヤーの現在のSPDの状態を新規SPDとして代入
        int NEWSSPD = PS.PSPDING;
        PS.SaveSPD = NEWSSPD;
        int NEWSMSPD = PS.PMAXSPD;
        PS.SaveMSPD = NEWSMSPD;
        //新規SPDを表示
        GetComponent<Text>().text = "SPD: " + NEWSSPD + "/" + NEWSMSPD;
    }
    
}