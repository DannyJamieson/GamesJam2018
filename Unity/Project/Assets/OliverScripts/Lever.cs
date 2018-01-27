using UnityEngine;

public class Lever : Switch {

    [SerializeField]
    private float interactionRadius;


    private void Awake()
    {
        GetComponent<SphereCollider>().radius = interactionRadius;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {         
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isBlack && collider.tag == "Black")
            {
                doorwayScript.blackActive = true;
            }
            else if(!isBlack && collider.tag == "White")
            {
                doorwayScript.whiteActive = true;
            }
            doorwayScript.CheckDoorActivity();
        }		
	}
   
}
