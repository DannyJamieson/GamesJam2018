using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLayerController : MonoBehaviour {
    Camera cam;
	// Use this for initialization
	void Start () {
        cam = this.GetComponent<Camera>();
        if (this.gameObject == GameManager.Instance.WhitePlayer)
        {
            cam.cullingMask = (1 << LayerMask.NameToLayer("White")) | (1 << LayerMask.NameToLayer("White Black"));
        }
        else
        {
            cam.cullingMask = (1 << LayerMask.NameToLayer("Black")) | (1 << LayerMask.NameToLayer("White Black"));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
