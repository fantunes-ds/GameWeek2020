using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSphere : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, 1);
    }
}
