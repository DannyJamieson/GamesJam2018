using UnityEngine;
using UnityEngine.UI;

public class LeverScript : BaseSwitch {

    public GameObject interactKey;

    private void Start()
    {
        interactKey.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        // If the object colliding with level is a player, proceed.
        if (other.gameObject.tag == "Black" || other.gameObject.tag == "White")
        {
            interactKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("e pressed by " + other.tag);
                if (isBlackSwitch && other.tag == "Black")
                {
                    doorScript.blackActivated = true;
                    Debug.LogError("black activated");
                }

                if (isWhiteSwitch && other.tag == "White")
                {
                    doorScript.whiteActivated = true;
                    Debug.LogError("White activated");
                }

                doorScript.CheckDoorStatus();
            }
        }
        else
        {
            interactKey.SetActive(false);
        }
    }
}
