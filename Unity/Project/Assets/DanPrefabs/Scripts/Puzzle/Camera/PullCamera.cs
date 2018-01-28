using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullCamera : BaseCamera {
    
    private bool rotate;
    private float startTime;
    private float journeyDistance;

    Quaternion startRot;
    Quaternion endRot;

    public enum CameraState { idleState, pullState }
    public CameraState currentCameraState;

    public GameObject pullTarget;
    public GameObject wat;

    public override void Start()
    {
        base.Start();

        currentCameraState = CameraState.idleState;
    }

    public override void FixedUpdate()
    {
        if (rotate)
            base.FixedUpdate();
    }

    void Update()
    {
        if (pullTarget == null)
            currentCameraState = CameraState.idleState;

        if (pullTarget != null)
            currentCameraState = CameraState.pullState;

        switch (currentCameraState) {
            case CameraState.idleState:
                rotate = true;
                break;

            case CameraState.pullState:
                rotate = false;
                var targetPosition = pullTarget.transform.position;
                targetPosition.y = transform.position.y;
                transform.LookAt(targetPosition);

                float speed = 2f;
                float step = speed * Time.deltaTime;
                pullTarget.transform.position = Vector3.MoveTowards(pullTarget.transform.position, transform.position, step);
                break;
        }
    }

    void PullPlayer() {
        
    }
}
