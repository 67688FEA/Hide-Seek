using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideController : MonoBehaviour {

    public Transform transformTree;
    private NavMeshAgent agent;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.destination = transformTree.position;
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", agent.speed);
    }

    // Update is called once per frame
    void Update () {

    }
}
