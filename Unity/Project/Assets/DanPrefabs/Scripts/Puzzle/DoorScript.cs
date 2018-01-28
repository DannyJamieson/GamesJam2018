using UnityEngine;
using UnityEngine.Networking;

public class DoorScript : NetworkBehaviour {

    public bool whiteActivated;

    [SyncVar]
    public bool blackActivated;




    public GameObject doorObject;
    
    [Command]
    public void CmdUpdateWhite()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAA");
        whiteActivated = true;
    }

	void Start () { 
        if (doorObject == null)
            Debug.Log("No door assigned in: " + gameObject.name);
	}

	public void CheckDoorStatus () {
        if (blackActivated && whiteActivated)
            doorObject.SetActive(false);
	}
}
