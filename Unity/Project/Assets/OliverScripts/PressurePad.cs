using UnityEngine;

public class PressurePad : Switch {

    public void OnTriggerEnter(Collider other)
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
    private void OnTriggerExit(Collider other)
    {
        if (isBlack)
        {
            doorwayScript.blackActive = false;
        }
        else
        {
            doorwayScript.whiteActive = false;
        }
        doorwayScript.CheckDoorActivity();
    }
}
