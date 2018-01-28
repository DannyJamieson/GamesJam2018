using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;
public class LeverScript : BaseSwitch {

    public GameObject interactKey;

    private void Start()
    {
        interactKey.SetActive(false);
    }

    //public void OnTriggerStay(Collider other)
    //{
    ////Debug.Log("e pressed while " + other.tag + " is within their circle");
    //if (isBlackSwitch && other.tag == "Black" && other.GetComponent<PlayerMovement>().isActiveAndEnabled)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        doorScript.blackActivated = true;
    //        Debug.LogError(doorScript.gameObject.name);
    //        Debug.LogError("black activated");
    //        doorScript.CheckDoorStatus();
    //    }
    //}

    //if (isWhiteSwitch && other.tag == "White" && other.GetComponent<PlayerMovement>().isActiveAndEnabled)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        doorScript.whiteActivated = true;
    //        other.GetComponent<PlayerMovement>().CmdSetWhiteLever(true);
    //        other.GetComponent<PlayerMovement>().SetWhiteLever(doorScript);
    //        Debug.LogError("White activated");
    //        Debug.Log(doorScript.gameObject.name);
    //        doorScript.CheckDoorStatus();

    //    }
    //}
    //}

    public void OnTriggerStay(Collider other)
    {
        // If the object is black, and black player interacts with it; trigger the bool.
        if (isBlackSwitch && other.tag == "Black" && Input.GetKeyDown(KeyCode.E))
        {
            doorScript.blackActivated = true;
        }

        if (isWhiteSwitch && other.tag == "White")
        {
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
