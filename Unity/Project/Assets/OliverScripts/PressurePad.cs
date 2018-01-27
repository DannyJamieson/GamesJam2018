using UnityEngine;

public class PressurePad : Switch {

    public void OnTriggerEnter(Collider other)
    {
       
        if (isBlack && other.tag == "Black")
        {
            doorwayScript.blackActive = true;
            doorwayScript.CheckDoorActivity();
        }
        else if (!isBlack && other.gameObject.tag == "White")
        {
            doorwayScript.whiteActive = true;
            doorwayScript.CheckDoorActivity();
        }
            
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (isBlack && other.tag == "Black")
        {
            doorwayScript.blackActive = false;
            doorwayScript.CheckDoorActivity();
        }
        else if (!isBlack && other.gameObject.tag == "White")
        {
            doorwayScript.whiteActive = false;
            doorwayScript.CheckDoorActivity();
        }
    }
}
