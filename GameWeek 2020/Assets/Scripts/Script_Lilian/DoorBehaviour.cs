using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animator myAnimator = null;

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
