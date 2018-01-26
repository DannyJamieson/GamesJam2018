using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoorway : MonoBehaviour {

    public bool blackActive;
    public bool whiteActive;

    private GameObject door;


    private void Awake()
    {
        door = transform.Find("Door").gameObject;
    }

    // Update is called once per frame
    void Update ()
    {
        if(blackActive && whiteActive)
        {
            door.SetActive(false);
        }
	}
}
