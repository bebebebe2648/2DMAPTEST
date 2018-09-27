using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTERStatus : MonoBehaviour
{
    
    public string mNAME;
    int mLEVEL;
    int mHP;
    public int mATK;
    int mSPD;
    int mEXP;
    int ontogeny;

    //MONSTERStatus
    //各種モンスターステータスを参照するための宣言
    MONSTERNAMEText MonsterNAME;
    MONSTERLEVELText MonsterLv;
    MONSTERHPText MonsterHP;
    MONSTERATKText MonsterATK;
    MONSTERSPDText MonsterSPD;
    MONSTEREXPText MonsterEXP;

    // Use this for initialization
    void Awake ()
    {
        //モンスターステータスの設定
        //モンスターのステータスを参照
        MonsterNAME = GameObject.Find("MONSTERNAMEText").GetComponent<MONSTERNAMEText>();
        MonsterLv = GameObject.Find("MONSTERLEVELText").GetComponent<MONSTERLEVELText>();
        MonsterHP = GameObject.Find("MONSTERHPText").GetComponent<MONSTERHPText>();
        MonsterATK = GameObject.Find("MONSTERATKText").GetComponent<MONSTERATKText>();
        MonsterSPD = GameObject.Find("MONSTERSPDText").GetComponent<MONSTERSPDText>();
        MonsterEXP = GameObject.Find("MONSTEREXPText").GetComponent<MONSTEREXPText>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    //5刻みでナンバリング
    public void Slime()
    {
        //総ステータス13（EXP:3）
        //係数1
        mLEVEL = 1;
        mNAME = "Slime";
        ontogeny = Random.Range(4, 11);
        mHP = ontogeny;
        ontogeny = Random.Range(2, 4);
        mATK = ontogeny;
        ontogeny = Random.Range(2, 6);
        mSPD = ontogeny;
        mEXP = 3;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }

    public void Goblin()
    {
        //総ステータス21（EXP:5）
        //係数2
        mLEVEL = 2;
        mNAME = "Goblin";
        ontogeny = Random.Range(8, 12);
        mHP = ontogeny;
        ontogeny = Random.Range(3, 5);
        mATK = ontogeny;
        ontogeny = Random.Range(2, 4);
        mSPD = ontogeny;
        mEXP = 4;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }

    public void Bee()
    {
        //総ステータス20（EXP:7）
        //係数2
        mLEVEL = 3;
        mNAME = "Bee";
        ontogeny = Random.Range(8, 13);
        mHP = ontogeny;
        ontogeny = Random.Range(2, 3);
        mATK = ontogeny;
        ontogeny = Random.Range(5, 9);
        mSPD = 3 * ontogeny;
        mEXP = 6;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }

    public void Bear()
    {
        //総ステータス32（EXP:12）
        //係数3
        mLEVEL = 4;
        mNAME = "Bear";
        ontogeny = Random.Range(8, 11);
        mHP = 3 * ontogeny;
        ontogeny = Random.Range(6, 8);
        mATK = ontogeny;
        ontogeny = Random.Range(6, 8);
        mSPD = ontogeny;
        mEXP = 7;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }

    public void LittleDeamon5()
    {
        //総ステータス32（EXP:12）
        //係数4
        mLEVEL = 5;
        mNAME = "LittleDeamon";
        ontogeny = Random.Range(4, 9);
        mHP = 2 * ontogeny;
        ontogeny = Random.Range(4, 8);
        mATK = ontogeny;
        ontogeny = Random.Range(10, 18);
        mSPD = ontogeny;
        mEXP = 8;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }

    public void KingSlime()
    {
        //総ステータス40（EXP:30）
        //係数8
        mLEVEL = 10;
        mNAME = "KingSlime";
        ontogeny = Random.Range(8, 11);
        mHP = 4 * ontogeny;
        ontogeny = Random.Range(5, 10);
        mATK = ontogeny;
        ontogeny = Random.Range(3, 8);
        mSPD = ontogeny;
        mEXP = 20;

        MonsterNAME.MONNAME = mNAME;
        MonsterLv.MONLv = mLEVEL;
        MonsterHP.MONHP = mHP;
        MonsterATK.MONATK = mATK;
        MonsterSPD.MONSPD = mSPD;
        MonsterEXP.MONEXP = mEXP;
    }
    
}
