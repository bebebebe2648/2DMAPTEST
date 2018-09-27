using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTERATKText: MonoBehaviour
{
    
    public int MONATK;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<Text>().text = "ATK: 0";
    }
	
	// Update is called once per frame
	void Update ()
    {
        int NEWMOBATK = MONATK;
        //新規ATKを表示
        GetComponent<Text>().text = "ATK: " + NEWMOBATK;
    }
    
}