using UnityEngine;
using UnityEngine.Networking;

public class DoorScript : NetworkBehaviour {

    [SyncVar][HideInInspector]
    public bool blackActivated;
    [HideInInspector]
    public bool whiteActivated;

    [Tooltip("Reference to the doorObject, drag and drop the actual door model here.")]
    public GameObject doorObject;

	void Start ()
    { 
        // If the door is not assigned in inspector, call an error.
        if (doorObject == null)
            Debug.LogError("No door assigned in: " + gameObject.name);
	}

	public void CheckDoorStatus ()
    {
        // Check the status of the door, if both checks pass, disable the door.
        // This can later be changed to some sort of animation or sumfin.
        if (blackActivated && whiteActivated)
            doorObject.SetActive(false);
	}
}
