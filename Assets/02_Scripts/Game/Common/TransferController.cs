using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class TransferController : MonoBehaviour {

    public Transform destination;
    public GameObject particle;
    public LayerMask layer;
    public float delayTime = 1f;

    private GameObject player;
    private WaitForSeconds delay;

    void Awake()
    {
        delay = new WaitForSeconds(delayTime);
    }

    IEnumerator Activate(Collider other)
    {
        if (destination)
        {
            if (particle) particle.SetActive(true);
            yield return delay;
            if (particle) particle.SetActive(true);
            other.gameObject.transform.position = destination.position;
            other.gameObject.transform.rotation = destination.rotation;
            if (other.gameObject.layer == 14)
            {
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                other.gameObject.GetComponent<Animator>().speed = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsTransferable(other))
        {
            StartCoroutine(Activate(other));
        }
    }

    bool IsTransferable(Collider other)
    {
        return 0 != (layer.value & 1 << other.gameObject.layer);
    }

}
