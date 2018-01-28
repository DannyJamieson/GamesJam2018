using UnityEngine;
using UnityEngine.Networking;

public class BaseSwitch : NetworkBehaviour {

    /// <summary>
    /// This is the base class for the camera system,
    /// with this base object we declare the basic variables for the door system to work.
    /// We also carry out some check to make sure we don't get any errors.
    /// Additional functionality needs to be added in the separate scripts that inherit from this class.
    /// </summary>

    [HideInInspector]
    public  DoorScript doorScript;       // Reference to the door script.

    [Header("Base Varaibles")]
    [Tooltip("This is the reference to the door that this script will affect, drag in the door prefab here.")]
    public GameObject targetObject;     // Target of the script.
    [Tooltip("Set this to true, if this is a button for the black player.")]
    public bool isBlackSwitch;          // Reference to the black state of switch.
    [Tooltip("Set this to true, if this is a button for the white player.")]
    public bool isWhiteSwitch;          // Reference to the white state of switch.

	private void Awake ()
    {
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
