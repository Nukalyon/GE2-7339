using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    //private Levier levier;
    [SerializeField] private float detectionRange = 4f;
    private IInteractable interactable;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Interagir
            interactable?.Interact();
        }
        
        RaycastDetection();
    }

    private void RaycastDetection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionRange))
        {
            IInteractable i = hit.collider.GetComponent<IInteractable>();
            if (i != null)
            {
                interactable = i;
            }
            else
            {
                interactable = null;
            }
        }
        else
        {
            interactable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray.origin, ray.direction * detectionRange);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        // Check si l'objet est interactable
        IInteractable i = other.GetComponent<IInteractable>();
        if (i != null)
        {
            interactable = i;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // enelever l'option d'interaction
        IInteractable i = other.GetComponent<IInteractable>();
        if(i == interactable)
        {
            interactable = null;
        }
    }*/
}
