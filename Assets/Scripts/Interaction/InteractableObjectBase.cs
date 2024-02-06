using UnityEngine;

public abstract class InteractableObjectBase : MonoBehaviour, IInteractable
{
    //[SerializeField] private float inputTime = 0.5f;
    public abstract void Interact();
}
