using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONSTERLEVELText : MonoBehaviour
{
    
    public int MONLv;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Text>().text = "Lv.0";
    }
	
	// Update is called once per frame
	void Update ()
    {
        int NEWMOBLv = MONLv;
        //新規SPDを表示
        GetComponent<Text>().text = "Lv." + NEWMOBLv;
    }
    
}
