using UnityEngine;

public class PPadScript : BaseSwitch {

    /// <summary>
    /// This is the pressure pad script for the pressure pad puzzle object.
    /// In order for this object to work, both of the players must stand on
    /// the pressure plates at the same time, this will trigger the door to open.
    /// </summary>

    public void OnTriggerEnter(Collider other)
    {
        // If the object is black, and black player interacts with it; trigger the bool.
        if (isBlackSwitch && other.tag == "Black") {
            doorScript.blackActivated = true;
        }

        // If the object is white, and white player interacts with it; trigger the bool.
        if (isWhiteSwitch && other.tag == "White") {
            doorScript.whiteActivated = true;
        }

        // Check the status of the door, and update it.
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
