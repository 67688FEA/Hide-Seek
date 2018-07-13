using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerController : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float gravity = 20.0f;

    private float horizontal;
    private float vertical;
    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;
    private float speed;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        speed = horizontal * horizontal + vertical * vertical;
        if (controller.isGrounded)
        {
            animator.SetFloat("Speed", speed);
            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
