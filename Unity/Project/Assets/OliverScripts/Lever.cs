using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    [SerializeField]
    bool isBlack;

    [SerializeField]
    private LeverOpenDoorway doorwayScript;



	// Update is called once per frame
	void OnMouseOver()
    {
                
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isBlack)
            {
                doorwayScript.blackActive = true;
            }
            else
            {
                doorwayScript.whiteActive = true;
            }
        }		
	}
}
