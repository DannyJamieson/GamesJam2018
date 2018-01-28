using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BaseSwitch : NetworkBehaviour {

    public DoorScript doorScript;       // Reference to the door script.
    public GameObject targetObject;     // Target of the script.
    public bool isBlackSwitch;          // Reference to the black state of switch.
    public bool isWhiteSwitch;          // Reference to the white state of switch.

	private void Awake () {
        if (targetObject == null)
            Debug.LogError("Target missing for BaseSwitch on: " + gameObject.name);

        // If there is no door script on the object, return
        // because there is nothing we can do with it.
        if (targetObject.GetComponent<DoorScript>() == null)
            Debug.LogError("No door script on target! - " + gameObject.name);
        else
            doorScript = targetObject.GetComponent<DoorScript>();
    }
}
