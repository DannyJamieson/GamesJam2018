using UnityEngine;

public class Lever : Switch {



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
            doorwayScript.CheckDoorActivity();
        }		
	}
}
