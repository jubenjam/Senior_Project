using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatController : MonoBehaviour
{
    public CharacterController2D controller;
    public BoxCollider2D hurtBox;
    public LayerMask WhatIsHurt;
    public UnityEvent OnDeathEvent;
    private bool hit;
    public Animator animator;
    private bool right = true;
    private float movement = 0f;
    public float leftbound = 0f;
    public float rightbound = 10f;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hit = hurtBox.IsTouchingLayers(WhatIsHurt);
    }
    void FixedUpdate()
    {
        float moveTo = 0;
        //Move character (fixedDeltaTime makes sure movement is at same speed on different computers)
        if (!right && movement > leftbound) {
            right = false;
            movement -= speed * Time.fixedDeltaTime;
            moveTo -= speed * Time.fixedDeltaTime;
        }
        else
            right = true;
        if (right && movement < rightbound)
        {
            right = true;
            movement += speed * Time.fixedDeltaTime;
            moveTo += speed * Time.fixedDeltaTime;
        }
        else
            right = false;
        controller.Move(moveTo, false, false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hit)
        {
            animator.SetBool("IsDead", true);
            OnDeathEvent.Invoke();
        }
    }


}
