using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsText : MonoBehaviour
{
    Moving Move;
    public int Stairs = 1;
    public int NEWStairs;

    // Use this for initialization
    void Awake ()
    {
        Move = GameObject.Find("Moving").GetComponent<Moving>();
        GetComponent<Text>().text = Stairs + "F";
    }
	
	// Update is called once per frame
	void Update () 
    {
        NEWStairs = Move.NOWStairsing;
        Move.SaveStairs = NEWStairs;
        GetComponent<Text>().text = NEWStairs + "F";
    }
}
