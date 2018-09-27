using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDeleteButton : MonoBehaviour
{
    GameManagement GETManagement;

    // Use this for initialization
    void Start ()
    {
        GETManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClick()
    {
        GETManagement.Delete();
    }
}