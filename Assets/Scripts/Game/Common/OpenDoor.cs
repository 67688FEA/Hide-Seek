using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public Material originMaterial;
    public Material activeMaterial;
    public GameObject targetDoor;
    public float delayTime=2f;

    private Animator openAnimator;
    WaitForSeconds delay;

    private void Start()
    {
        openAnimator = targetDoor.GetComponent<Animator>();
        delay = new WaitForSeconds(delayTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = activeMaterial;
            openAnimator.SetBool("open", true);
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator CloseDoor()
    {
        yield return delay;
        openAnimator.SetBool("open", false);               
        gameObject.GetComponent<MeshRenderer>().material = originMaterial;
    }

}
