using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEVELText : MonoBehaviour
{
    
    PlayerStatus PS;

    //初期値
    public int pLEVEL = 1;

	// Use this for initialization
	void Awake ()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GetComponent<Text>().text = "Lv." + pLEVEL;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //PlayerStatusからプレイヤーの現在のEXPの状態を新規EXPとして代入
        int NEWSLv = PS.PLvING;
        PS.SaveLv = NEWSLv;
        //新規Lvを表示
        GetComponent<Text>().text = "Lv." + NEWSLv;
    }
    
}