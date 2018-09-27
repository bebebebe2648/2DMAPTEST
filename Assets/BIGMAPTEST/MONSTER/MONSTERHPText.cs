using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTERHPText : MonoBehaviour
{
    
    public int MONHP;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<Text>().text = "HP: 0";
    }
	
	// Update is called once per frame
	void Update ()
    {
        int NEWMOBHP = MONHP;
        //新規HPを表示
        GetComponent<Text>().text = "HP: " + NEWMOBHP;
    }
    
}