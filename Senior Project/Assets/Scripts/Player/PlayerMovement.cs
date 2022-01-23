using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //get horizontal movement
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        //check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        //check for crouching    
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    // FixedUpdate is called a fixed amount of times per second
    void FixedUpdate()
    {
        //Move character (fixedDeltaTime makes sure movement is at same speed on different computers)
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false; //don't jump forever
    }
}
