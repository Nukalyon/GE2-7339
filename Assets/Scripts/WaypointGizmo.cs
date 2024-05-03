using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour
{
    [SerializeField] private float minimumHeight = 2;
    
#if UNITY_EDITOR 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Ray ray = new Ray(this.transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, minimumHeight))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.2f);
        }
        
        Gizmos.DrawSphere(transform.position, 0.5f);
        
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * minimumHeight);
        
       
    }
#endif


}
