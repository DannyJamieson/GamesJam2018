using UnityEngine;

public class TriggerScript : MonoBehaviour {

    [SerializeField]
    GameObject target;

    public enum cameraType { pull, push }
    public cameraType _cameraType;

    void Update()
    {
        switch (_cameraType) {
            case cameraType.pull:
                GetComponentInParent<PullCamera>().pullTarget = target;
                break;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Black" || other.gameObject.tag == "White")
            target = other.gameObject;
    }

    public void OnTriggerExit(Collider other) {
        target = null;
    }
}
