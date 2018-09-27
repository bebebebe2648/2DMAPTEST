using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReStartButton : MonoBehaviour
{
    Moving Movement;

    // Use this for initialization
    void Awake ()
    {
        Movement = GameObject.Find("Moving").GetComponent<Moving>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClick()
    {
        Movement.Restart();
    }
}
