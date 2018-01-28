using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof(NetworkTransform))]
public class PlatformMovementChildren : NetworkBehaviour {
    [HideInInspector]
    public float startTime;
    [HideInInspector]
    public bool trigger = false;
    [SerializeField]
    float randomMovement = 5;
    BoxCollider myCol;

    // public float rotValue

    float journeyDistance;
 
    float movementSpeed;
    Vector3 endPos;
    Vector3 startPos;
    Quaternion endRot;
    Quaternion startRot;
    Material myMaterial;

    //nice fucking comments DAN
    private void Start()
    {
        if (transform.parent.GetComponent<PlatformMoving>() == null)
        {
            return;
        }

        try
        {
            myCol = GetComponent<BoxCollider>();
            myCol.enabled = false;
        }
        catch { }
        //myMaterial = new Material(GetComponent<Renderer>().material);
        // GetComponent<Renderer>().material = myMaterial;



        movementSpeed = Random.Range(10, 15);

        endPos = transform.position;
        endRot = transform.rotation;

        //set a random rotation
        transform.position = new Vector3(
            Random.Range(transform.position.x - randomMovement, transform.position.x + randomMovement),
             Random.Range(transform.position.y - randomMovement, transform.position.y + randomMovement),
              Random.Range(transform.position.z - randomMovement, transform.position.z + randomMovement)
            );    
        //rotate the object by a random amount
        transform.Rotate(
            Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)
            );
        startPos = transform.position;
        //start rotation is the new rotation
        startRot = transform.rotation;
        journeyDistance = Vector3.Distance(startPos, endPos);
    }

    void Update () {
        if (trigger)
        {
            SetNewPos();
            SetNewRot();
            
            if (Time.time - startTime > 4)
            {
                this.enabled = false;
            }
        }
	}


    void SetNewPos() {
        float distCovered = (Time.time - startTime) * movementSpeed;
        float fracJourney = distCovered / journeyDistance;
        transform.position = Vector3.Lerp(startPos,endPos,fracJourney);
        if(fracJourney > 0.8)
        {
            myCol.enabled = true;
        }

      //  Color newColour = myMaterial.color;
       // newColour.a = fracJourney;
        //myMaterial.color = newColour;
    }

    void SetNewRot()
    {
        float distCovered = (Time.time - startTime) * movementSpeed;
        float fracJourney = distCovered / journeyDistance;
        transform.rotation = Quaternion.Slerp(startRot ,endRot, fracJourney);
    }
}
