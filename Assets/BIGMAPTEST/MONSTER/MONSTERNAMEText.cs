using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTERNAMEText : MonoBehaviour
{
    
    public string MONNAME = "MONSTER!";

	// Use this for initialization
	void Awake ()
    {
        GetComponent<Text>().text = MONNAME;
    }
	
	// Update is called once per frame
	void Update ()
    {
        string NEWMOBNAME = MONNAME;
        //新規ATKを表示
        GetComponent<Text>().text = NEWMOBNAME;
    }
    
}