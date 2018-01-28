using UnityEngine;

public class BaseCamera : MonoBehaviour {

    /// <summary>
    /// This is the base class for the camera system,
    /// with this base object the camera will always be rotating unless its static.
    /// Additional functionality needs to be added in seprate scripts that inherit from this class.
    /// </summary>

    [Header("Base Variables")]
    [Tooltip("This is the reference to the trigger cone, this is the 'view' range of the camera that will affect the players. It is used to mimic actual vision cone.")]
    public GameObject triggerCone;
    [Tooltip("Set the camera to static, so that it will not rotate.")]
    public bool isStatic;
    [Tooltip("Set the rotation amount for the camera, this is what it will be multiplied by.")]
    public float rotateAmount;

    public void Start()
    {
        // If the rotateAmount is set to zero, freak out (unless the camera is static).
        if (!isStatic && rotateAmount == 0)
        {
            Debug.LogError(gameObject.name + " has no rotation amount. Setting as static.");
            isStatic = true;    // Set the camera to static, because no rotation amount was set.
        }

        if (!triggerCone)
            Debug.LogError("Trigger cone missing in: " + gameObject.name);
        
    }

    public void FixedUpdate ()
    {
        // If the camera is not static, rotate it using rotateAmount; otherwise ignore.
        if(!isStatic)
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotateAmount);
    }
}
