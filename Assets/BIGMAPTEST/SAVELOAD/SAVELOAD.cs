using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SAVELOAD : MonoBehaviour
{
    StairsText Floor;
    Moving Move;
    PlayerStatus PS;
    EXPText EXP;

    [Serializable]
    public class SAVEdata
    {
        public int sLv;
        public int sHP;
        public int sMHP;
        public int sATK;
        public int sMATK;
        public int sSPD;
        public int sMSPD;
        public int sEXP;
        public int sNEXP;

        public int sFloor;
    }

    string savePath = "Assets/BIGMAPTEST/SAVELOAD/saveData.json";

    // Use this for initialization
    void Start ()
    {
        Floor = GameObject.Find("StairsText").GetComponent<StairsText>();
        Move = GameObject.Find("Moving").GetComponent<Moving>();
        PS = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
        EXP = GameObject.Find("EXPText").GetComponent<EXPText>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        SAVEdata PLAYdata = new SAVEdata();

        PLAYdata.sLv = PS.SaveLv;
        PLAYdata.sHP = PS.SaveHP;
        PLAYdata.sMHP = PS.SaveMHP;
        PLAYdata.sATK = PS.SaveATK;
        PLAYdata.sMATK = PS.SaveMATK;
        PLAYdata.sSPD = PS.SaveSPD;
        PLAYdata.sMSPD = PS.SaveMSPD;
        PLAYdata.sEXP = PS.SaveEXP;
        PLAYdata.sNEXP = EXP.SaveNEEDEXP;
        PLAYdata.sFloor = Floor.NEWStairs;

        Debug.Log("sHP: " + PLAYdata.sHP);
        Debug.Log("sATK: " + PLAYdata.sATK);

        bf.Serialize(file, PLAYdata);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            SAVEdata PLAYdata = (SAVEdata)bf.Deserialize(file);
            file.Close();

            Debug.Log("sHP: " + PLAYdata.sHP);
            Debug.Log("sATK: " + PLAYdata.sATK);

            PS.PNOWLv = 0;
            PS.PNOWHP = 0;
            PS.PMAXHP = 0;
            PS.PNOWATK = 0;
            PS.PMAXATK = 0;
            PS.PNOWSPD = 0;
            PS.PMAXSPD = 0;
            PS.PNOWEXP = 0;
            EXP.NEEDEXP = 0;

            PS.PLvING = 0;
            PS.PHPING = 0;
            PS.PMAXHP = 0;
            PS.PATKING = 0;
            PS.PMAXATK = 0;
            PS.PSPDING = 0;
            PS.PMAXSPD = 0;
            PS.SUMEXP = 0;

            Move.NOWStairsing = 0;
            Floor.NEWStairs = 0;

            PS.PNOWLv = PLAYdata.sLv;
            PS.PNOWHP = PLAYdata.sHP;
            PS.PMAXHP = PLAYdata.sMHP;
            PS.PNOWATK = PLAYdata.sATK;
            PS.PMAXATK = PLAYdata.sMATK;
            PS.PNOWSPD = PLAYdata.sSPD;
            PS.PMAXSPD = PLAYdata.sMSPD;
            PS.PNOWEXP = PLAYdata.sEXP;
            EXP.NEEDEXP = PLAYdata.sNEXP;

            PS.PLvING = PLAYdata.sLv;
            PS.PHPING = PLAYdata.sHP;
            PS.PMAXHP = PLAYdata.sMHP;
            PS.PATKING = PLAYdata.sATK;
            PS.PMAXATK = PLAYdata.sMATK;
            PS.PSPDING = PLAYdata.sSPD;
            PS.PMAXSPD = PLAYdata.sMSPD;
            PS.SUMEXP = PLAYdata.sEXP;
            EXP.NEEDEXP = PLAYdata.sNEXP;

            Move.NOWStairsing = PLAYdata.sFloor;
            Floor.NEWStairs = PLAYdata.sFloor;
        }
    }
}
