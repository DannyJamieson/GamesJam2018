using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {
    public GameObject playerGraphic;
    public GameObject playerVisor;
    public FirstPersonController fps;
    public Camera playerCam;

    public GameObject[] toDisable;

    public Text tagText;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            //fps = this.GetComponent<FirstPersonController>();
            fps.enabled = false;
            playerCam.enabled = false;

        }
        else
        {
            GameManager.Instance.SetPlayer(gameObject);
            tagText.text = gameObject.tag;
        } 
    }
  
    public override void OnStartLocalPlayer() {
        //playerGraphic.GetComponent<MeshRenderer>().material.color = Color.blue;

        tagText = GameObject.Find("Text").GetComponent<Text>();
        playerGraphic.SetActive(false);
        playerVisor.SetActive(false);
       

    }
}
