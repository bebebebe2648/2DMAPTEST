using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTERSET : MonoBehaviour
{
    
    MONSTERStatus MONDATASET;
    EventScene MONCount;

    int SET;

    // Use this for initialization
    void Awake ()
    {
        MONDATASET = GameObject.Find("MONSTERStatus").GetComponent<MONSTERStatus>();
        MONCount = GameObject.Find("EventScene").GetComponent<EventScene>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void MonsterSET()
    {
        if (MONCount.MKILLCount < 3)
        {
            SET = Random.Range(1, 3);
            switch (SET)
            {
                case 1:
                    MONDATASET.Slime();
                    break;

                case 2:
                    MONDATASET.Goblin();
                    break;
            }
        }

        if (MONCount.MKILLCount > 3)
        {
            SET = Random.Range(1, 4);
            switch (SET)
            {
                case 1:
                    MONDATASET.Slime();
                    break;

                case 2:
                    MONDATASET.Goblin();
                    break;

                case 3:
                    MONDATASET.Bee();
                    break;
            }
        }

        if (MONCount.MKILLCount > 5)
        {
            SET = Random.Range(2, 5);
            switch (SET)
            {
                case 2:
                    MONDATASET.Goblin();
                    break;

                case 3:
                    MONDATASET.Bee();
                    break;

                case 4:
                    MONDATASET.Bear();
                    break;
            }
        }

        if (MONCount.MKILLCount > 8)
        {
            SET = Random.Range(3, 6);
            switch (SET)
            {
                case 2:
                    MONDATASET.Goblin();
                    break;

                case 3:
                    MONDATASET.Bee();
                    break;

                case 4:
                    MONDATASET.Bear();
                    break;

                case 5:
                    MONDATASET.LittleDeamon5();
                    break;
            }
        }

        if (MONCount.MKILLCount == 15)
        {
            MONDATASET.KingSlime();
        }
    }
    
}
