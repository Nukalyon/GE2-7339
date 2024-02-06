using UnityEngine;
using UnityEngine.Events;

public class GenericInteractableObject : InteractableObjectBase
{
    [SerializeField] private UnityEvent onInteract;
    public override void Interact()
    {
        //Null check
        onInteract?.Invoke();
    }
}
