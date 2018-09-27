using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTEREXPText : MonoBehaviour
{
    
    public int MONEXP;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<Text>().text = "EXP: 0";
    }
	
	// Update is called once per frame
	void Update ()
    {
        int NEWMOBEXP = MONEXP;
        //新規EXPを表示
        GetComponent<Text>().text = "EXP: " + NEWMOBEXP;
    }
    
}