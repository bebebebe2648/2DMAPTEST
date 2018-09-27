using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScene : MonoBehaviour
{

    Moving Movement;
    PlayerStatus PS;
    MONSTERSET Monster;

    //MONSTERStatus
    //各種モンスターステータスを参照するための宣言
    MONSTERHPText MonsterHP;
    MONSTERATKText MonsterATK;
    MONSTERSPDText MonsterSPD;
    MONSTEREXPText MonsterEXP;

    //イベントフラグ(0~3)
    int EventFlag;
    int ItemFlag;

    //メッセージ
    public string Message;    //メッセージUIに返す文章
    public bool MessageFlag;  //メッセージフラグ、trueのときにメッセージを出力する
    
    //
    public bool BattleFlag;  //
    public bool magFlag;     //
    public int magCount;     //

    //モンスターを倒した回数
    public int MKILLCount = 0;
    public int SaveMKCount;
    
    //速度の倍率
    int SPDmag;

    //死亡フラグ
    public int pDEAD = 0;
    public int mDEAD = 0;
    //優先権
    public int SPDpriority;
    
    // Use this for initialization
    void Awake ()
    {
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        Movement = GameObject.Find("Moving").GetComponent<Moving>();
        //モンスターステータスの設定
        //モンスターのステータスを参照
        MonsterHP = GameObject.Find("MONSTERHPText").GetComponent<MONSTERHPText>();
        MonsterATK = GameObject.Find("MONSTERATKText").GetComponent<MONSTERATKText>();
        MonsterSPD = GameObject.Find("MONSTERSPDText").GetComponent<MONSTERSPDText>();
        MonsterEXP = GameObject.Find("MONSTEREXPText").GetComponent<MONSTEREXPText>();

        Monster = GameObject.Find("MONSTERSET").GetComponent<MONSTERSET>();
    }

    // Update is called once per frame
    void Update ()
    {
          
    }

    public void EventTime()
    {
        //ランダムに3種のイベントフラグを立てる
        EventFlag = Random.Range(0, 3);

        switch (EventFlag)
        {
            case 0:
                //戦闘
                BattleFlag = true;
                BattleScene();
                break;

            case 1:
                //アイテム発見
                ItemGetScene();
                break;

            case 2:
                //何も起こらない
                NothingScene();
                break;
        }
    }

    void BattleScene()
    {
        //生存フラグを立てる
        pDEAD = 0;
        mDEAD = 0;

        Monster.MonsterSET();

        //プレイヤーステータス
        int PLAYNOWHP = PS.PNOWHP;    //現在のプレイヤーのHPを代入
        int PLAYNOWATK = PS.PNOWATK;  //現在のプレイヤーのATKを代入
        int PLAYNOWSPD = PS.PNOWSPD;  //現在のプレイヤーのSPDを代入
        int PLAYNOWEXP = PS.PNOWEXP;  //現在のプレイヤーのEXPを代入

        //モンスターステータス
        int MOBHP = MonsterHP.MONHP;    //現在のモンスターのHPを代入
        int MOBATK = MonsterATK.MONATK;  //現在のモンスターのATKを代入
        int MOBSPD = MonsterSPD.MONSPD;  //現在のモンスターのSPDを代入
        int MOBEXP = MonsterEXP.MONEXP;  //現在のモンスターのEXPを代入

        //プレイヤーとモンスターのSPDを比較
        //比較後、優先権のフラグを与える
        //プレイヤーのが早い場合、優先権を与える処理
        if (PLAYNOWSPD > MOBSPD)
        {
            SPDpriority = 1;
        }

        //モンスターのが早い場合、優先権を与える処理
        else if (MOBSPD > PLAYNOWSPD)
        {
            SPDpriority = 0;
        }

        //双方の速度が同じ場合、ランダムに優先権を与える処理
        else if (PLAYNOWSPD == MOBSPD)
        {
            SPDpriority = Random.Range(0, 2);
        }

        //戦闘開始！
        BattleProgress01:

        //プレイヤーのSPDがモンスターより高い場合
        //優先権があるとき、処理
        if (SPDpriority != 0)
        {
            //速度倍率計算
            SPDmag = PLAYNOWSPD / MOBSPD;

            //ダメージ計算
            int HP = MOBHP - PLAYNOWATK;
            MOBHP = HP;

            //モンスターの死亡判定
            if (MOBHP <= 0)
            {
                mDEAD = 1;
                MKILLCount++;
                SaveMKCount = MKILLCount;

                //ゲーム続行処理
                //プレイヤーステータスへの反映
                //HP
                PS.PNOWHP = PLAYNOWHP;  //現在のHPを更新
                PS.SaveHP = PLAYNOWHP;  //現在のHPをセーブ
                PS.PHPING = PLAYNOWHP;  //UI表示に
                //EXP
                PS.PNOWEXP = PLAYNOWEXP + MOBEXP;  //累計EXPの計算・更新
                PS.SaveEXP = PS.PNOWEXP;           //累計EXPのセーブ
                PS.SUMEXP = PS.PNOWEXP;            //UI表示に

                MessageFlag = true;
                Message = "YOU WIN!EXP" + MOBEXP + "GET!";

                //戦闘終了処理へ
                goto BattleProgress02;
            }

            //モンスターが生存している場合、モンスターの反撃処理
            else
            {
                //ダメージ計算
                HP = PLAYNOWHP - MOBATK;
                PLAYNOWHP = HP;

                //プレイヤーの死亡判定
                if (PLAYNOWHP <= 0)
                {
                    pDEAD = 1;
                    //ゲーム終了処理
                    MessageFlag = true;
                    Message = "YOU DEAD!";

                    //ゲーム中断・初期化処理
                    Movement.Restart();                 //初期化処理へ
                    Movement.ReStartFlag = true;
                    //再開処理へ
                    goto BattleProgress03;
                }
            }

            //追加攻撃
            if (SPDmag >= 2)
            {
                magFlag = true;
                //すでに1回攻撃してるため
                SPDmag = SPDmag - 1;
                magCount = SPDmag;

                while (SPDmag == 0)
                {
                    //ダメージ計算
                    HP = MOBHP - PLAYNOWATK;
                    MOBHP = HP;

                    //モンスターの死亡判定
                    if (MOBHP <= 0)
                    {
                        mDEAD = 1;
                        MKILLCount++;
                        SaveMKCount = MKILLCount;

                        //ゲーム続行処理
                        //プレイヤーステータスへの反映
                        //HP
                        PS.PNOWHP = PLAYNOWHP;  //現在のHPを更新
                        PS.SaveHP = PLAYNOWHP;  //現在のHPをセーブ
                        PS.PHPING = PLAYNOWHP;  //UI表示に
                        //EXP
                        PS.PNOWEXP = PLAYNOWEXP + MOBEXP;  //累計EXPの計算・更新
                        PS.SaveEXP = PS.PNOWEXP;           //累計EXPのセーブ
                        PS.SUMEXP = PS.PNOWEXP;            //UI表示に

                        MessageFlag = true;
                        Message = "YOU WIN!EXP" + MOBEXP + "GET!";

                        //戦闘終了処理へ
                        goto BattleProgress02;
                    }

                    SPDmag--;
                }
            }
        }

        //プレイヤーのSPDがモンスターより低い場合
        //優先権がないとき、処理
        else
        {
            //速度倍率計算
            SPDmag = MOBSPD / PLAYNOWSPD;

            //ダメージ計算
            int HP = PLAYNOWHP - MOBATK;
            PLAYNOWHP = HP;

            //プレイヤーの死亡判定
            if (PLAYNOWHP <= 0)
            {
                pDEAD = 1;

                //ゲーム終了処理
                MessageFlag = true;
                Message = "YOU DEAD!";

                //ゲーム中断・初期化処理
                Movement.Restart();                 //初期化処理へ
                Movement.ReStartFlag = true;
                //再開処理へ
                goto BattleProgress03;
            }

            //プレイヤーが生存している場合、プレイヤーの反撃処理
            else
            {
                //ダメージ計算
                HP = MOBHP - PLAYNOWATK;
                MOBHP = HP;

                //モンスターの死亡判定
                if (MOBHP <= 0)
                {
                    mDEAD = 1;
                    MKILLCount++;
                    SaveMKCount = MKILLCount;

                    //ゲーム続行処理
                    //プレイヤーステータスへの反映
                    //HP
                    PS.PNOWHP = PLAYNOWHP;  //現在のHPを更新
                    PS.SaveHP = PLAYNOWHP;  //現在のHPをセーブ
                    PS.PHPING = PLAYNOWHP;  //UI表示に
                    //EXP
                    PS.PNOWEXP = PLAYNOWEXP + MOBEXP;  //累計EXPの計算・更新
                    PS.SaveEXP = PS.PNOWEXP;           //累計EXPのセーブ
                    PS.SUMEXP = PS.PNOWEXP;            //UI表示に

                    MessageFlag = true;
                    Message = "YOU WIN!EXP" + MOBEXP + "GET!";

                    //戦闘終了処理へ
                    goto BattleProgress02;
                }
            }

            if (SPDmag >= 2)
            {
                magFlag = true;
                //すでに1回攻撃してるため
                SPDmag = SPDmag - 1;
                magCount = SPDmag;

                while (SPDmag == 0)
                {
                    //ダメージ計算
                    HP = PLAYNOWHP - MOBATK;
                    PLAYNOWHP = HP;

                    //プレイヤーの死亡判定
                    if (PLAYNOWHP <= 0)
                    {
                        pDEAD = 1;

                        //ゲーム終了処理
                        MessageFlag = true;
                        Message = "YOU DEAD!";

                        //ゲーム中断・初期化処理
                        Movement.Restart();                 //初期化処理へ
                        Movement.ReStartFlag = true;
                        //再開処理へ
                        goto BattleProgress03;
                    }

                    SPDmag--;
                }
            }
        }

        //プレイヤー・モンスターが生存している
        if (pDEAD != 1 && mDEAD != 1)
        {
            //戦闘に戻る
            goto BattleProgress01;
        }

        //再開処理
        //リスタートフラグを立てる
        BattleProgress03:

        //戦闘終了処理
        BattleProgress02:
        MessageFlag = true;
        //Message = "GO AWAY...!";
    }

  


    void ItemGetScene()
    {
        MessageFlag = true;

        ItemFlag = Random.Range(0, 5);

        switch (ItemFlag)
        {
            case 0:
                int HP = PS.PMAXHP + 2;
                //PS.SaveMHP = HP;
                PS.PMAXHP = HP;
                Message = "ItemGet! MAXHP: +2";
                break;

            case 1:
                int MATK = PS.PMAXATK + 1;
                //PS.SaveMATK = MATK;
                PS.PMAXATK = MATK;
                int ATK = PS.PNOWATK + 1;
                PS.PNOWATK = ATK;
                //PS.SaveATK = ATK;
                PS.PATKING = ATK;
                Message = "ItemGet! MAXATK: +1";
                break;

            case 2:
                ATK = PS.PNOWATK - 1;
                PS.PNOWATK = ATK;
                //PS.SaveATK = ATK;
                PS.PATKING = ATK;
                Message = "PoisonTrap!? ATK: -1";
                break;

            case 3:
                int MSPD = PS.PMAXSPD + 1;
                //PS.SaveMSPD = MSPD;
                PS.PMAXSPD = MSPD;
                int SPD = PS.PNOWSPD + 1;
                PS.PNOWSPD = SPD;
                //PS.SaveSPD = SPD;
                PS.PSPDING = SPD;
                Message = "ItemGet! MAXSPD: +1";
                break;

            case 4:
                SPD = PS.PNOWSPD - 1;
                PS.PNOWSPD = SPD;
                //PS.SaveSPD = SPD;
                PS.PSPDING = SPD;
                Message = "MudTrap!? SPD: -1";
                break;
        }
    }

    void NothingScene()
    {
        MessageFlag = true;

        int HP = PS.PNOWHP + 3;

        if (HP >= PS.PMAXHP)
        {
            HP = PS.PMAXHP;
        }

        //PS.SaveHP = HP;
        PS.PHPING = HP;

        Message = "BreakTime! HP : +3";
    }
    
}