using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    
    //PLAYERStatus
    //各種プレイヤーステータスを参照するための宣言
    LEVELText PlayerLEVEL;
    HPText PlayerHP;
    ATKText PlayerATK;
    SPDText PlayerSPD;
    EXPText PlayerEXP;

    //プレイヤーの初期値保存
    public int PStartLv;       //プレイヤーの初期Lv
    public int PStartHP;       //プレイヤーの初期HP
    public int PStartATK;      //プレイヤーの初期ATK
    public int PStartSPD;      //プレイヤーの初期SPD
    public int PStartEXP;      //プレイヤーの初期EXP

    //プレイヤーの最大値ステータス
    public int PMAXHP;
    public int PMAXATK;
    public int PMAXSPD;

    //プレイヤーの最大値ステータスを保存
    public int SaveMHP;
    public int SaveMATK;
    public int SaveMSPD;

    //プレイヤーの進行ステータスを保存
    public int PNOWLv;
    public int PNOWHP;
    public int PNOWATK;
    public int PNOWSPD;
    public int PNOWEXP;

    //プレイヤーの現在ステータスを保存
    public int SaveLv;
    public int SaveHP;
    public int SaveATK;
    public int SaveSPD;
    public int SaveEXP;

    //プレイヤーの進行ステータスをUIに表示させる
    public int PLvING;           //プレイヤーのLv進行状況
    public int PHPING;           //プレイヤーのHP進行状況
    public int PATKING;          //プレイヤーのATK進行状況
    public int PSPDING;          //プレイヤーのSPD進行状況
    public int SUMEXP;           //プレイヤーの累計経験値

    //増加した現在の値
    public int UpHP;
    public int UpATK;
    public int UpSPD;

    // Use this for initialization
    void Awake ()
    {
        //プレイヤーステータスの設定
        //プレイヤーのステータスを参照
        PlayerLEVEL = GameObject.Find("LEVELText").GetComponent<LEVELText>();
        PlayerHP = GameObject.Find("HPText").GetComponent<HPText>();
        PlayerATK = GameObject.Find("ATKText").GetComponent<ATKText>();
        PlayerSPD = GameObject.Find("SPDText").GetComponent<SPDText>();
        PlayerEXP = GameObject.Find("EXPText").GetComponent<EXPText>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PStatusSET()
    {
        //プレイヤーステータス
        //初期値保存
        PStartLv = PlayerLEVEL.pLEVEL;  //Lv初期値
        PStartHP = PlayerHP.pHP;        //HP初期値
        PStartATK = PlayerATK.pATK;     //ATK初期値
        PStartSPD = PlayerSPD.pSPD;     //SPD初期値
        PStartEXP = PlayerEXP.pEXP;     //EXP初期値

        //初期値を代入して、現在値とする
        PNOWLv = PStartLv;
        PNOWHP = PStartHP;
        PNOWATK = PStartATK;
        PNOWSPD = PStartSPD;
        PNOWEXP = PStartEXP;

        //現在値をセーブする
        //SaveLv = PNOWLv;
        //SaveHP = PNOWHP;
        //SaveATK = PNOWATK;
        //SaveSPD = PNOWSPD;
        //SaveEXP = PNOWEXP;

        //ステータス最大値に初期値を代入
        PMAXHP = PStartHP;
        PMAXATK = PStartATK;
        PMAXSPD = PStartSPD;

        //ステータス最大値をセーブ
        //SaveMHP = PMAXHP;
        //SaveMATK = PMAXATK;
        //SaveMSPD = PMAXSPD;

        //UI表示用
        PLvING = PStartLv;
        PHPING = PStartHP;
        PATKING = PStartATK;
        PSPDING = PStartSPD;
        SUMEXP = PStartEXP;
    }

    public void LEVELUP()
    {
        //レベルを+1する
        int Lv = PNOWLv + 1;
        PNOWLv = Lv;
        PLvING = PNOWLv;
        //MAXHPが2～5増える
        int HP = Random.Range(2, 6);
        int MAXHP = PMAXHP + HP;
        PMAXHP = MAXHP;
        //MAXATKが1～3増える
        int ATK = Random.Range(1, 4);
        int MAXATK = PMAXATK + ATK;
        PMAXATK = MAXATK;
        //MAXSPDが1～3増える
        int SPD = Random.Range(1, 4);
        int MAXSPD = PMAXSPD + SPD;
        PMAXSPD = MAXSPD;

        //現在HPを増加分だけ増やす
        UpHP = HP;
        //現在ATKを増加分だけ増やす
        UpATK = ATK;
        //現在SPDを増加分だけ増やす
        UpSPD = SPD;

        //現在HPに最大HPを代入
        PNOWHP = PMAXHP;
        PHPING = PNOWHP;
        //現在ATKに増加ATKを代入
        int PlusATK = PNOWATK + ATK;
        PNOWATK = PlusATK;
        PATKING = PNOWATK;
        //現在SPDに増加SPDを代入
        int PlusSPD = PNOWSPD + SPD;
        PNOWSPD = PlusSPD;
        PSPDING = PNOWSPD;

        //レベル上がったフラグをfalseに
        PlayerEXP.LvUPFlag = false;  
    }

    public void PStatusReset()
    {
        //初期値を代入
        PNOWLv = PStartLv;
        PNOWHP = PStartHP;
        PNOWATK = PStartATK;
        PNOWSPD = PStartSPD;
        PNOWEXP = PStartEXP;

        //最大値に初期値を代入
        PMAXHP = PStartHP;
        PMAXATK = PStartATK;
        PMAXSPD = PStartSPD;
        PlayerEXP.NEEDEXP = 10;

        //UI表示用
        PLvING = PStartLv;
        PHPING = PStartHP;
        PATKING = PStartATK;
        PSPDING = PStartSPD;
        SUMEXP = PStartEXP;
    } 
}