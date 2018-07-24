using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public float distanceAway;         
    public float distanceUp;         
    public float smooth;
    public Image image; 

    private GameObject hovercraft;   
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    Transform follow;

    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
        image.enabled = true;
        StartCoroutine(ChangeTransparency());
    }

    void LateUpdate()
    {
        targetPosition = follow.position + (follow.up * distanceUp) - (follow.forward * distanceAway);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        targetRotation = follow.rotation;
        transform.rotation = targetRotation;
        transform.Rotate(new Vector3(17f, 0, 0));
    }

    IEnumerator ChangeTransparency()
    {
        //image.color = new Color(0, 0, 0, 0);
        while (!Mathf.Approximately(image.color.a, 0f))
        {
            image.color = new Color(0, 0, 0, Mathf.MoveTowards(image.color.a, 0f, 0.5f * Time.deltaTime));
            yield return null;
        }
    }

}
