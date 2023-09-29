using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float yVelocity = 0;
    private bool onGround = true;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider groundChecker;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float gravity = 1f;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        onGround = true;
    }
    public void OnTriggerExit(Collider other)
    {
        onGround = false;
    }

    private void Move()
    {
       
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
            } 
        }
        else
        {
            yVelocity -= gravity;
        }

        move.y = yVelocity;

        controller.Move(move * Time.deltaTime * speed);

        if(move != Vector3.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
