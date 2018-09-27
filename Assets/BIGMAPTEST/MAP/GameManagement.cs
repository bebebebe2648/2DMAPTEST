using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    Moving Movement;
    PlayerStatus PS;
    EXPText EXP;
    EventScene ES;

    //
    public string Floorkey = "highScore";

    //
    public string SAVEMKCount = "highScore";

    //
    public string SAVELv = "highScore";
    public string SAVEHP = "highScore";
    public string SAVEATK = "highScore";
    public string SAVESPD = "highScore";
    public string SAVEEXP = "highScore";

    //
    public string SAVEMHP = "highScore";
    public string SAVEMATK = "highScore";
    public string SAVEMSPD = "highScore";
    public string SAVENEEDEXP = "highScore";

    // Use this for initialization
    void Start()
    {
        Movement = GameObject.Find("Moving").GetComponent<Moving>();
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        EXP = GameObject.Find("EXPText").GetComponent<EXPText>();
        ES = GameObject.Find("EventScene").GetComponent<EventScene>();
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
    /*
    public void Save()
    {
        //階層数をセーブ
        PlayerPrefs.SetInt(Floorkey, Movement.SaveStairs);

        //
        PlayerPrefs.SetInt(SAVEMKCount, ES.SaveMKCount);

        //現在値をセーブ
        PlayerPrefs.SetInt(SAVELv, PS.SaveLv);
        PlayerPrefs.SetInt(SAVEHP, PS.SaveHP);
        PlayerPrefs.SetInt(SAVEATK, PS.SaveATK);
        PlayerPrefs.SetInt(SAVESPD, PS.SaveSPD);
        PlayerPrefs.SetInt(SAVEEXP, PS.SaveEXP);

        //最大値をセーブ
        PlayerPrefs.SetInt(SAVEMHP, PS.SaveMHP);
        PlayerPrefs.SetInt(SAVEMATK, PS.SaveMATK);
        PlayerPrefs.SetInt(SAVEMSPD, PS.SaveMSPD);
        PlayerPrefs.SetInt(SAVENEEDEXP, EXP.NEEDEXP);
    }

    public void Load()
    {
        SceneManager.LoadScene("LoadTEST");
        //階層をセーブしたところからロード
        Movement.SaveStairs = PlayerPrefs.GetInt(Floorkey, 1);
        Movement.NOWStairsing = Movement.SaveStairs;
        Movement.Stairsing = Movement.NOWStairsing;

        //
        ES.MKILLCount = PlayerPrefs.GetInt(Floorkey, 1);

        //現在のステータス
        //LV
        PS.SaveLv = PlayerPrefs.GetInt(SAVELv, 1);
        PS.PLvING = PS.SaveLv;
        PS.PNOWLv = PS.PLvING;
        //HP
        PS.SaveHP = PlayerPrefs.GetInt(SAVEHP, 30);
        PS.PHPING = PS.SaveHP;
        PS.PNOWHP = PS.PHPING;
        //ATK
        PS.SaveATK = PlayerPrefs.GetInt(SAVEATK, 5);
        PS.PATKING = PS.SaveATK;
        PS.PNOWATK = PS.PATKING;
        //SPD
        PS.SaveSPD = PlayerPrefs.GetInt(SAVESPD, 5);
        PS.PSPDING = PS.SaveSPD;
        PS.PNOWSPD = PS.PSPDING;
        //EXP
        PS.SaveEXP = PlayerPrefs.GetInt(SAVEEXP, 0);
        PS.SUMEXP = PS.SaveEXP;
        PS.PNOWEXP = PS.SUMEXP;

        //最大ステータス
        //HP
        PS.SaveMHP = PlayerPrefs.GetInt(SAVEMHP, 30);
        PS.PMAXHP = PS.SaveMHP;
        //ATK
        PS.SaveMATK = PlayerPrefs.GetInt(SAVEMATK, 5);
        PS.PMAXATK = PS.SaveMATK;
        //SPD
        PS.SaveMSPD = PlayerPrefs.GetInt(SAVEMSPD, 5);
        PS.PMAXSPD = PS.SaveMSPD;
        //NEEDEXP
        EXP.SaveNEEDEXP = PlayerPrefs.GetInt(SAVENEEDEXP, 10);
        EXP.NEEDEXP = EXP.SaveNEEDEXP;
        
    }
    */
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}