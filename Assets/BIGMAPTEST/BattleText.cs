using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleText : MonoBehaviour
{
    
    EventScene MS;
    PlayerStatus PS;
    MONSTERStatus MDATA;

    string SPDMessage0;
    string SPDMessage1;
    string PATKMS;
    string PMOREATKMS;
    string MATKMS;
    string MMOREATKMS;

    // Use this for initialization
    void Awake ()
    {
        MS = GameObject.Find("EventScene").GetComponent<EventScene>();
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        MDATA = GameObject.Find("MONSTERStatus").GetComponent<MONSTERStatus>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (MS.BattleFlag == true)
        {
            if (MS.SPDpriority != 0)
            {
                //プレイヤーの先制攻撃
                SPDMessage1 = "PLAYER's Attack! ";
                //プレイヤーのダメージ
                PATKMS = PS.PNOWATK + "Damage!!";
                //モンスターのダメージ
                MATKMS = MDATA.mATK + "Damage!!";
                GetComponent<Text>().text = SPDMessage1 + PATKMS + "\n" + MDATA.mNAME + "'s Attack! " + MATKMS + "\n";

                if (MS.magFlag == true)
                {
                    PMOREATKMS = "PLAYER's Attack! " + PS.PNOWATK + "Damage!!";
                    GetComponent<Text>().text = SPDMessage1 + PATKMS + "\n" + MDATA.mNAME + "'s Attack! " + MATKMS + "\n" + PMOREATKMS + " * " + MS.magCount;
                    MS.magFlag = false;
                }
            }

            else if (MS.SPDpriority == 0)
            {
                //モンスターの先制攻撃
                SPDMessage0 = MDATA.mNAME + "'s Attack! ";
                //モンスターのダメージ
                MATKMS = MDATA.mATK + "Damage!!";
                //プレイヤーのダメージ
                PATKMS = PS.PNOWATK + "Damage!!";
                GetComponent<Text>().text = SPDMessage0 + MATKMS + "\n" + "PLAYER's Attack! " + PATKMS + "\n";

                if (MS.magFlag == true)
                {
                    MMOREATKMS = MDATA.mNAME+ "'s Attack! " + MDATA.mATK + "Damage!!";
                    GetComponent<Text>().text = SPDMessage0 + MATKMS + "\n" + "PLAYER's Attack! " + PATKMS + "\n" + MMOREATKMS + " * " + MS.magCount;
                    MS.magFlag = false;
                }
            }

            //バトルメッセージ終了
            MS.BattleFlag = false;
        }
	}
    
}