using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animator myAnimator = null;

    private Transform colliderWorldTransform = null;
    
    private void Start()
    {
        colliderWorldTransform = GetComponent<BoxCollider>().transform;
    }

    private void Update()
    {
        GetComponent<BoxCollider>().transform.position = colliderWorldTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!myAnimator)
            return;
            
        if (other.CompareTag("Player"))
            myAnimator.SetTrigger("PlayerClose");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!myAnimator)
            return;
        
        if (other.CompareTag("Player"))
            myAnimator.SetTrigger("PlayerClose");
    }
}
