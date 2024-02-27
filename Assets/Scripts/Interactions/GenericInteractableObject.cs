using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericInteractableObject : InteractableObjectBase
{
    [SerializeField] private UnityEvent onInteract;
    
    public override void Interact()
    {
        onInteract?.Invoke();
    }
}
