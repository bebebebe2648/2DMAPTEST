using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    //GameManagement GETManagement;
    SAVELOAD SAVE;

    // Use this for initialization
    void Awake ()
    {
        //GETManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        SAVE = GameObject.Find("SAVELOAD").GetComponent<SAVELOAD>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClick()
    {
        SAVE.Save();
    }
}