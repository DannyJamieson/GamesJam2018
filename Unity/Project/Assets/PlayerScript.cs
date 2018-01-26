using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed, jumpSpeed, gravity;
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;




    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Is the controller on the ground?
        if (controller.isGrounded)
        {
            //feed moveDirection with input
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //multiply it by speed
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        //applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
