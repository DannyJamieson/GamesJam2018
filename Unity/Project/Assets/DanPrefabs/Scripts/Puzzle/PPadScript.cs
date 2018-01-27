using UnityEngine;

public class PPadScript : BaseSwitch {
    public void OnTriggerEnter(Collider other)
    {
        // If the object is black, and black player interacts with it; trigger the bool.
        if (isBlackSwitch && other.tag == "Black") {
            doorScript.blackActivated = true;
        }

        if (isWhiteSwitch && other.tag == "White") {
            doorScript.whiteActivated = true;
        }

        doorScript.CheckDoorStatus();
    }

    public void OnTriggerExit(Collider other)
    {
        // We step off the pressure plate, we set the tirgger back to false.
        if (isBlackSwitch)
            doorScript.blackActivated = false;

        if (isWhiteSwitch)
            doorScript.whiteActivated = false;
    }
}
