using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityBlindness : MonoBehaviour {
    [SerializeField]
    bool nearPlayer;
	[SerializeField]
	float maxRadius;
    [SerializeField]
    float blindRadius;
	public Transform otherPlayer;
    public Image canvasImage;
	
	// Use this for initialization
	void Start(){
        SphereCollider col = gameObject.AddComponent<SphereCollider>();
		col.radius = maxRadius;
		col.isTrigger = true;
		//find a way to get the other player
	}
	
	// Update is called once per frame
	void Update () {
		if(nearPlayer){
			float radius = blindRadius - (otherPlayer.position - this.transform.position).magnitude;
            Color color = canvasImage.color;
            if (radius > 0){
                //Make them blind
                color.a = 1;
                canvasImage.color = color;
				return;
			}
			float alpha = 1 - Mathf.Abs(radius)/(maxRadius-blindRadius);
            color.a = alpha;
            canvasImage.color = color;
			
			
		}
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearPlayer = false;
            Color color = canvasImage.color;
            color.a = 0;
            canvasImage.color = color;   
        }

    }
}
