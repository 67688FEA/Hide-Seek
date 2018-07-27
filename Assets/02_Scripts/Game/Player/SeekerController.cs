using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeekerController : MonoBehaviour {

    public float moveSpeed = 4.0f;
    public float rotateSpeed = 60.0f;
    public float gravity = 20.0f;
    public float delayTime = 2.5f;

    private float horizontal;
    private float vertical;
    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;
    private float speed;
    private WaitForSeconds delay;
    private bool inputable = true;

    // Use this for initialization
    void Start ()
    {
        delay = new WaitForSeconds(delayTime);
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (inputable)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            speed = horizontal * horizontal + vertical * vertical;
            if (controller.isGrounded)
            {
                animator.SetFloat("Speed", speed);
                moveDirection = new Vector3(0, 0, vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= moveSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            transform.Rotate(Vector3.up, horizontal * rotateSpeed * Time.deltaTime, Space.Self);
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == 14)
        {
            inputable = false;
            StartCoroutine(AttackHider(hit));
        }
    }

    IEnumerator AttackHider(ControllerColliderHit hit)
    {
        animator.SetTrigger("Attack");
        hit.gameObject.GetComponent<Animator>().SetTrigger("Death");
        hit.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        yield return delay;
        inputable = true;
        hit.gameObject.SetActive(false);
    }

}
