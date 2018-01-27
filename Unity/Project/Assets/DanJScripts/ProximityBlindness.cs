using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityBlindness : MonoBehaviour {
    [SerializeField]
    bool nearPlayer = false;
	[SerializeField]
	float maxRadius;
    [SerializeField]
    float blindRadius;
    public Image canvasImage;
    SphereCollider MySphereCollider;
    
    // Use this for initialization
    void Start(){
        MySphereCollider = gameObject.AddComponent<SphereCollider>();
        MySphereCollider.radius = maxRadius;
        MySphereCollider.isTrigger = true;
        canvasImage = GameObject.Find("Blind Canvas").GetComponentInChildren<Image>();
        LayerMask lm = new LayerMask();
        lm.value = 6;
        lm.value = 8;
		//find a way to get the other player
	}
	
	// Update is called once per frame
	void Update () {
		if(nearPlayer){
			float radius = blindRadius - GetRadius();
            Color color = canvasImage.color;
            if (radius > 0){
                color.a = 1;
                canvasImage.color = color;
				return;
			}
			float alpha = 1 - Mathf.Abs(radius)/(maxRadius-blindRadius);
            color.a = alpha;
            canvasImage.color = color;
			
			
		}
	}

    float GetRadius()
    {
        try
        {
            return (GameManager.Instance.BlackPlayer.transform.position - GameManager.Instance.WhitePlayer.transform.position).magnitude;
        }
        catch
        {
            GameManager.Instance.WhitePlayer = GameObject.FindGameObjectWithTag("White");
            return (GameManager.Instance.BlackPlayer.transform.position - GameManager.Instance.WhitePlayer.transform.position).magnitude;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Black" || other.gameObject.tag == "White") && other.gameObject!= this.transform.parent.gameObject)
        {
            nearPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Black" || other.gameObject.tag == "White") && other.gameObject != this.transform.parent.gameObject)
        {
            nearPlayer = false;
            Color color = canvasImage.color;
            color.a = 0;
            canvasImage.color = color;   
        }

    }
}
