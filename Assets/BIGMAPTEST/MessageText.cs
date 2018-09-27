using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    
    //ゲーム管理GameManagementから参照するため
    EventScene MSScript;
    EventScene ReceiveFlag;
    EXPText EXPText;
    PlayerStatus PS;

    //メッセージ保存リスト
    List<string> MessageStorage = new List<string>();
    //メッセージ表示リスト
    List<string> MessageDisplay = new List<string>();

    string NEWMessage;
    

    // Use this for initialization
    void Awake()
    {
        MSScript = GameObject.Find("EventScene").GetComponent<EventScene>();
        ReceiveFlag = GameObject.Find("EventScene").GetComponent<EventScene>();
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        EXPText = GameObject.Find("EXPText").GetComponent<EXPText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ReceiveFlag.MessageFlag == true)
        {
            //一時的なリストGETMessage(参照・取得)、リストMessageStorage(保存)、リストMessageDisplay(保持・表示・改行)の流れ
            //1.新規メッセージ[A][B][C][D][E][F]がGETMessageに入って、[A]がMessageStorageに[A]入り・・・
            //MessageStorage[A]→MessageDisplay[A]、MessageStorageの[A]を削除
            //2.新規メッセージ[B][C][D][E][F]がGETMessageに入って、[B]がMessageStorageに[B]入り
            //MessageStorage[B]→MessageDisplay[A][B]、MessageStorageの[B]を削除

            //GETMessageから参照・取得して、MessageStorageに保存
            AddMessage(ref MessageStorage);

            NEWMessage = MessageStorage[0];
            Debug.Log("MessageStorage[0]:" + MessageStorage[0]);
            Debug.Log("NEWMessage:" + NEWMessage);

            MessageDisplay.Add(NEWMessage);
            Debug.Log("MessageDisplay[0]:" + MessageDisplay[0]);

            //MessageStorageに保存していた最初のメッセージを削除
            MessageStorage.RemoveAt(0);

            //リストMessageStorage、リストMessageDisplayの要素数をカウント
            var MessageStorageCount = MessageStorage.Count;
            var MessageDisplayCount = MessageDisplay.Count;

            Debug.Log("MessageStorageCount:" + MessageStorageCount);
            Debug.Log("MessageDisplayCount:" + MessageDisplayCount);

            while (MessageDisplayCount <= 10)
            {
                if (MessageDisplayCount == 1)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 2)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 3)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 4)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 5)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 6)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n" + MessageDisplay[5] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 7)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n" + MessageDisplay[5] + "\n"
                                                + MessageDisplay[6] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 8)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n" + MessageDisplay[5] + "\n"
                                                + MessageDisplay[6] + "\n" + MessageDisplay[7] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                if (MessageDisplayCount == 9)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n" + MessageDisplay[5] + "\n"
                                                + MessageDisplay[6] + "\n" + MessageDisplay[7] + "\n" + MessageDisplay[8] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }

                //表示上限
                if (MessageDisplayCount == 10)
                {
                    GetComponent<Text>().text = MessageDisplay[0] + "\n" + MessageDisplay[1] + "\n" + MessageDisplay[2] + "\n"
                                                + MessageDisplay[3] + "\n" + MessageDisplay[4] + "\n" + MessageDisplay[5] + "\n"
                                                + MessageDisplay[6] + "\n" + MessageDisplay[7] + "\n" + MessageDisplay[8] + "\n"
                                                + MessageDisplay[9] + "\n";
                    ReceiveFlag.MessageFlag = false;
                    break;
                }
            }

            //表示上限に達したら、リストMessageDisplay[0][1]の2個の要素を削除
            if (MessageDisplayCount == 10)
            {
                MessageDisplay.RemoveAt(0);
            }
            
        }

        if (EXPText.LvUPMSFlag == true)
        {
            GetComponent<Text>().text = "LEVEL UP! HP:+" + PS.UpHP +" ATK: +" + PS.UpATK + " SPD: +" + PS.UpSPD;
            EXPText.LvUPMSFlag = false;
        }
    }

    //検索キーワード「ref 参照型 値渡し」
    //イメージを以下に残す:値型と参照型
    //【値型】
    //A=5,B=3
    //B=A
    //B=5
    //A=10
    //B=5
    //
    //【参照型】
    //A=5,B=3
    //B=A
    //B=5
    //A=10
    //B=10

    //一時的なリストGETMessageで新規メッセージを参照・取得
    void AddMessage(ref List<string> GETMessage)
    {
        //一時的なリストGETMessageを作成
        GETMessage = new List<string>();
        //新規メッセージを参照・取得
        GETMessage.Add(MSScript.Message);
        Debug.Log("GETMessage[0]" + GETMessage[0]);
    }
    
}