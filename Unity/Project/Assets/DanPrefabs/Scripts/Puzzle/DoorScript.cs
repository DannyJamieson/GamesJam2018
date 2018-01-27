using UnityEngine;
using UnityEngine.Networking;

public class DoorScript : NetworkBehaviour {

    [SyncVar]
    public bool blackActivated;
    [SyncVar]
    public bool whiteActivated;

    public GameObject doorObject;

	void Start () {
        if (doorObject == null)
            Debug.Log("No door assigned in: " + gameObject.name);
	}

    public void Update() {
        CheckDoorStatus();
    }

	public void CheckDoorStatus () {
        if (blackActivated && whiteActivated)
            doorObject.SetActive(false);
	}
}
