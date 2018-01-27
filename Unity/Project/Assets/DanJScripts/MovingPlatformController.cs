using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour {
    public float timePerTrip;
    public Vector3 EndPos;
    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            Mathf.Lerp(startPos.x,EndPos.x,GetPosition()),
            Mathf.Lerp(startPos.y, EndPos.y, GetPosition()),
            Mathf.Lerp(startPos.z, EndPos.z, GetPosition())


            );
	}


    float GetPosition()
    {
        float currentPos = Time.time % (timePerTrip * 2 + 2);
        if(currentPos < timePerTrip)
        {
            return currentPos / timePerTrip;
        }
        if(currentPos> timePerTrip && currentPos + 1 < timePerTrip)
        {
            return 1f;
        }
        if(currentPos > timePerTrip * 2 + 1)
        {
            return 0;
        }
        return 1f - (currentPos - (timePerTrip + 1));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(EndPos, new Vector3(1, 1, 1));
    }
}
