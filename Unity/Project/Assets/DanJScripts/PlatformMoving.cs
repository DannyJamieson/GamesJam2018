using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {
    List<PlatformMovementChildren> movingPlatforms = new List<PlatformMovementChildren>();

    [SerializeField]
    bool test = false;

    private void Start()
    {
        for(int i =0; i<transform.childCount; i++)
        {
            movingPlatforms.Add(transform.GetChild(i).GetComponent<PlatformMovementChildren>());
        }
    }

    private void Update()
    {
        if (test)
        {
            TriggerChildren();
            test = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "White" || other.gameObject.tag == "Black")
        {
            TriggerChildren();
            
        }
    }
    
    void TriggerChildren()
    {
        foreach (PlatformMovementChildren child in movingPlatforms)
        {
            child.startTime = Time.time;
            child.trigger = true;
        }
       // GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
