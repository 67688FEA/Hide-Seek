using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float distanceAway;         
    public float distanceUp;         
    public float smooth;

    private GameObject hovercraft;   
    private Vector3 targetPosition;   

    Transform follow;

    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;                                   
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        transform.LookAt(follow);
    }

}
