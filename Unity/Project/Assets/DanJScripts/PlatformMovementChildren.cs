using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementChildren : MonoBehaviour {
    public float startTime;
    public bool trigger = false;
    float degreesPerSecond;
    public float randomMovement;
    public float rotValue;
    public float journeyDistance;
    public float movementSpeed;
    Vector3 endPos;
    Vector3 startPos;
    Quaternion endRot;
    Quaternion startRot;

    //nice fucking comments DAN
    private void Start()
    {
        movementSpeed = Random.Range(10, 15);
        degreesPerSecond = movementSpeed * 4.5f;

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
            if (Time.time - startTime > 5)
            {
                this.enabled = false;
            }
        }
	}


    void SetNewPos() {
        float distCovered = (Time.time - startTime) * movementSpeed;
        float fracJourney = distCovered / journeyDistance;
        transform.position = Vector3.Lerp(startPos,endPos,fracJourney);
    }

    void SetNewRot()
    {
        float distCovered = (Time.time - startTime) * movementSpeed;
        float fracJourney = distCovered / journeyDistance;
        transform.rotation = Quaternion.Slerp(startRot ,endRot, fracJourney);
    }
}
