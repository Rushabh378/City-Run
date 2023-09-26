using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 1f;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        if(move != Vector3.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if(Input.GetButtonDown("Jump"))
            Debug.Log("jump button clicked.");

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump button clicked.");
            rigidBody.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
        }
    }
}
