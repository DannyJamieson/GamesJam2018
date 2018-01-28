using UnityEngine;

public class LeverScript : BaseSwitch {

    /// <summary>
    /// This is the lever class, for the lever puzzle game object.
    /// For this object to work, both players have to be in the range of the lever,
    /// but only the black player can activate the pull of the levers. If the players
    /// are not in the range of the lever, nothing will happen.
    /// </summary>

    [Header("GUI")]
    [Tooltip("This is the interact key GUI text.")]
    public GameObject interactKey;

    private void Start()
    {
        // On the start, disable the interaction text because we don't need it.
        interactKey.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        // If the object is black, and black player interacts with it; trigger the bool.
        // The player needs to press 'E' to open the door; only black player can open doors.
        if (isBlackSwitch && other.tag == "Black" && Input.GetKeyDown(KeyCode.E))
        {
            doorScript.blackActivated = true;
        }

        // If the object is white, and white player interacts with it; trigger the bool.
        if (isWhiteSwitch && other.tag == "White")
        {
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
