using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : NetworkBehaviour {
    public GameObject playerGraphic;
    public GameObject playerVisor;
    public FirstPersonController fps;
    public Camera playerCam;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            //fps = this.GetComponent<FirstPersonController>();
            fps.enabled = false;
            playerCam.enabled = false;
        }
    }

    public override void OnStartLocalPlayer() {
        //playerGraphic.GetComponent<MeshRenderer>().material.color = Color.blue;
        playerGraphic.SetActive(false);
        playerVisor.SetActive(false);
    }
}
