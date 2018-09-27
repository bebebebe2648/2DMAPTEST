using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTERSPDText : MonoBehaviour
{
    
    public int MONSPD;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<Text>().text = "SPD: 0";
    }
	
	// Update is called once per frame
	void Update ()
    {
        int NEWMOBSPD = MONSPD;
        //新規SPDを表示
        GetComponent<Text>().text = "SPD: " + NEWMOBSPD;
    }
    
}