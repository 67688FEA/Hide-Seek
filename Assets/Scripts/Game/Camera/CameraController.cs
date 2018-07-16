using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float distanceAway;         
    public float distanceUp;         
    public float smooth;

    private GameObject hovercraft;   
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    Transform follow;

    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        targetPosition = follow.position + (follow.up * distanceUp) - (follow.forward * distanceAway);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        targetRotation = follow.rotation;
        transform.rotation = targetRotation;
        transform.Rotate(new Vector3(17f, 0, 0));
    }
}
