using UnityEngine;

public class OpenDoorway : MonoBehaviour {

    public bool blackActive;
    public bool whiteActive;

    private GameObject door;


    private void Awake()
    {
        door = transform.Find("Door").gameObject;
    }

    public void CheckDoorActivity()
    {
        if (blackActive && whiteActive)
        {
            door.SetActive(false);
        }
    }
}
