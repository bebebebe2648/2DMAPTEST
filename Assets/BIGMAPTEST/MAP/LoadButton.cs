using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    //GameManagement GETManagement;
    SAVELOAD LOAD;

    // Use this for initialization
    void Awake ()
    {
        //GETManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        LOAD = GameObject.Find("SAVELOAD").GetComponent<SAVELOAD>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClick()
    {
        LOAD.Load();
    }
}