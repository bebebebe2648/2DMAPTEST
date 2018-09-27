using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    [SerializeField]
    public GameObject BIGPLAYERS;  //プレイヤーオブジェクトのプレハブ
    [SerializeField]
    GameObject BIGDesting;  //目的地オブジェクトのプレハブ

    StairsText NOWStairs;          //階層表示参照
    PlayerStatus PS;
    EventScene GETEvent;

    public GameObject BIGPLAYER;
    GameObject BIGDestination;

    //生成した目的地のゲームオブジェクトを入れるためのリスト作成
    public List<GameObject> DestList = new List<GameObject>();
    //遠かった目的地のゲームオブジェクトを退避させるためのリスト作成
    List<GameObject> FarList = new List<GameObject>();

    //X軸・Y軸移動用
    int Rootpriority;          //優先権(0~1)
    float BIGstep = 4;         //移動速度

    //階層
    public int StartStairs;   //階層初期値
    public int Stairsing;     //現在の階層
    public int SaveStairs;    //階層数の保存
    public int NOWStairsing;  //UI表示用

    //リスタートフラグ
    public bool ReStartFlag;

    // Use this for initialization
    void Start ()
    {
        NOWStairs = GameObject.Find("StairsText").GetComponent<StairsText>();
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        GETEvent = GameObject.Find("EventScene").GetComponent<EventScene>();

        PS.PStatusSET();
        StairsSET();
        StartPositionSET();
        Generate();
        RootSearch();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void StartPositionSET()
    {
        //プレイヤーオブジェクトを生成、同時にプレハブから切り離す
        BIGPLAYER = Instantiate(BIGPLAYERS);
        //プレハブから切り離したプレイヤーオブジェクトに初期座標を入れる
        BIGPLAYER.transform.position = new Vector2(15, -15);
    }

    public void Generate()
    {
        //目的地オブジェクトを生成＆座標代入、リストに加えて複製させるループ
        for (int i = 0; i < 5; i++)
        {
            //目的地オブジェクトを生成、同時にプレハブから切り離す
            BIGDestination = Instantiate(BIGDesting);
            //プレハブから切り離した目的地オブジェクトにランダムの座標を入れる
            BIGDestination.transform.position = new Vector2(Random.Range(1, 30), Random.Range(-29, 0));
            //目的地オブジェクトリストに加える
            DestList.Add(BIGDestination);
        }
    }

    void Move()
    {
        if (BIGPLAYER.transform.position.x != DestList[0].transform.position.x)
        {
            BIGPLAYER.transform.position = Vector2.MoveTowards(BIGPLAYER.transform.position, new Vector2(DestList[0].transform.position.x, BIGPLAYER.transform.position.y), BIGstep * Time.deltaTime);
        }

        if (BIGPLAYER.transform.position.x == DestList[0].transform.position.x)
        {   
            if (BIGPLAYER.transform.position.y != DestList[0].transform.position.y)
            {
                BIGPLAYER.transform.position = Vector2.MoveTowards(BIGPLAYER.transform.position, new Vector2(BIGPLAYER.transform.position.x, DestList[0].transform.position.y), BIGstep * Time.deltaTime);

                if (BIGPLAYER.transform.position == DestList[0].transform.position)
                {
                    //イベント発生
                    GETEvent.EventTime();

                    if (ReStartFlag == false)
                    {
                        Debug.Log("破壊する: " + DestList[0]);
                        Destroy(DestList[0]);
                        DestList.Clear();
                        DestList.AddRange(FarList);
                        var DestCount = DestList.Count;
                        Debug.Log("復旧したDest: " + DestCount);
                        FarList.Clear();
                        var FarListCount = FarList.Count;
                        Debug.Log("空のFarList: " + FarListCount);
                    }

                    ReStartFlag = false;

                    //次の目的地検索
                    ObjectSearch();
                }
            }
        }
    }


    public void RootSearch()
    {
        MoveProgress01:

        var BIGDestCount = DestList.Count;
        Debug.Log("BIGDestCount!: " + BIGDestCount);
        var FarListCount = FarList.Count;
        Debug.Log(FarListCount);

        //最短距離の目的地を求めたとき、処理
        if (BIGDestCount == 1)
        {
            Debug.Log("破壊する座標は: " + DestList[0].transform.position);
            goto MoveProgress02;
        }

        //目的地A（現在地、目的地座標[0]）= 距離A,目的地B（現在地、目的地座標[1]) = 距離Bを比較
        //距離Aのが遠い場合処理
        //list_BIGDestination:[A][B][C][D][E][F]→list_BIGDestination[B][C][D][E][F]、list_FarPos:[A]という処理
        if (Vector2.Distance(BIGPLAYER.transform.position, DestList[0].transform.position) > Vector2.Distance(BIGPLAYER.transform.position, DestList[1].transform.position))
        {
            //目的地Aのゲームオブジェクトを退避リストに追加
            //目的地リストから目的地Aのゲームオブジェクトを削除
            FarList.Add(DestList[0]);
            DestList.RemoveAt(0);

            goto MoveProgress01;
        }

        //目的地A（現在地、目的地座標[0]）= 距離A と目的地B（現在地、目的地座標[1] = 距離Bを比較
        //距離Bのが遠い場合処理
        //list_BIGDestination:[A][B][C][D][E][F]→list_BIGDestination[A][C][D][E][F]、list_FarPos:[B]という処理
        if (Vector2.Distance(BIGPLAYER.transform.position, DestList[1].transform.position) > Vector2.Distance(BIGPLAYER.transform.position, DestList[0].transform.position))
        {
            //目的地Bのゲームオブジェクトを退避リストに追加
            //目的地リストから目的地Bのゲームオブジェクトを削除
            FarList.Add(DestList[1]);
            DestList.RemoveAt(1);

            goto MoveProgress01;
        }

        //目的地A（現在地、目的地座標[0]）= 距離A と目的地B（現在地、目的地座標[1]）= 距離Bを比較
        //距離Aと距離Bが同じ距離の場合処理
        if (Vector2.Distance(BIGPLAYER.transform.position, DestList[0].transform.position) == Vector2.Distance(BIGPLAYER.transform.position, DestList[1].transform.position))
        {
            //目的地オブジェクトリストの要素数が3つ以上ある時、処理
            //続きがあるのかのNULLチェック
            //list_BIGDestination:[B][C][D][E][F]、list_BIGDestination:[B][C]→[D][E][F]の要素があるかをチェックする処理
            if (BIGDestCount >= 3)
            {
                //目的地A（現在地、目的地座標[0]）= 距離A と目的地C（現在地、目的地座標[2]）= 距離Cを比較
                //距離Aのが遠い場合処理
                //list_BIGDestination:[A][B][C][D][E][F]→list_BIGDestination[C][D][E][F]、list_FarPos:[A][B]という処理
                if (Vector2.Distance(BIGPLAYER.transform.position, DestList[0].transform.position) > Vector2.Distance(BIGPLAYER.transform.position, DestList[2].transform.position))
                {
                    //目的地A[0]と目的地B[1]のゲームオブジェクトを退避リストに追加
                    //目的地リストから目的地Aと目的地Bのゲームオブジェクトを削除
                    FarList.AddRange(DestList.GetRange(0, 1));
                    DestList.RemoveRange(0, 1);

                    goto MoveProgress01;
                }
            }

            //リストが3つ以上ない時、処理
            else
            {
                //優先権チェック
                //0と1をランダムに与える
                Rootpriority = Random.Range(0, 2);

                //目的地A（現在地、目的地座標[0]）= 距離A と目的地B（現在地、目的地座標[1]）= 距離Bを比較
                //距離Aと距離Bが同じ距離の場合
                //優先権がないとき、list_BIGDestination:[A][B][C][D][E][F]→list_BIGDestination[B][C][D][E][F]、list_FarPos:[A]という処理
                if (Rootpriority != 1)
                {
                    //目的地Aのゲームオブジェクトを退避リストに追加
                    //目的地リストから目的地Aのゲームオブジェクトを削除
                    FarList.Add(DestList[0]);
                    DestList.RemoveAt(0);

                    goto MoveProgress01;
                }

                //目的地A（現在地、目的地座標[0]）= 距離A と目的地B（現在地、目的地座標[1]）= 距離Bを比較
                //距離Aと距離Bが同じ距離の場合処理
                //優先権があるとき、list_BIGDestination:[A][B][C][D]→list_BIGDestination[A][C][D]、list_FarPos:[B]という処理
                else
                {
                    //目的地Bのゲームオブジェクトを退避リストに追加
                    //目的地リストから目的地Bのゲームオブジェクトを削除
                    FarList.Add(DestList[1]);
                    DestList.RemoveAt(1);

                    goto MoveProgress01;
                }
            }
        }

        MoveProgress02:
        Debug.Log("移動開始！");
    }

    void ObjectSearch()
    {
        Debug.Log("オブジェクトサーチ！");

        //リストの要素数を数える
        //目的地オブジェクトの数を数える
        var BIGDestCount = DestList.Count;
        Debug.Log("BIGDestCount!!: " + BIGDestCount);

        //目的地オブジェクトがない場合再生成
        if (BIGDestCount == 0)
        {
            //再生成
            Generate();

            //現在の階層を+1する
            Stairsing = NOWStairsing + 1;
            //UI表示用に代入
            NOWStairsing = Stairsing;

            //リストの要素数を数える
            //再度、目的地オブジェクトの数を数える処理
            BIGDestCount = DestList.Count;
            Debug.Log("再生成後のBIGDestCount = " + BIGDestCount);
        }

        //生成された目的地オブジェクト全てに移動する処理
        if (BIGDestCount != 0)
        {
            RootSearch();
        }
    }

    void StairsSET()
    {
        //階層初期値の代入
        StartStairs = NOWStairs.Stairs;
        //現在の階層を代入
        Stairsing = StartStairs;
        //現在の階層をセーブ
        //SaveStairs = Stairsing;
        //UI表示用に代入
        NOWStairsing = Stairsing;
    }

    //死亡時
    public void StairsReset()
    {
        //現在の階層数に初期値を代入
        Stairsing = StartStairs;
        //UI表示用に代入
        NOWStairsing = Stairsing;
    }

    public void Restart()
    {
        //Invokeを使って、死亡判定から数秒待って再開
        //画面遷移でこのシーンを上書きする
        //A→A'という風に
        SceneManager.LoadScene("BIGMAPTEST");
    }
}