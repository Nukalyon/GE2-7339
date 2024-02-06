using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float detectionRange = 2.0f;
    private IInteractable interactable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Interagir
            /*
            if(interactable != null)
            {
                interactable.Interact();
            }
            */
            //Plus compact
            interactable?.Interact();
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter player");
        IInteractable i = other.GetComponent<IInteractable>();
        if(i != null)
        {
            interactable = i;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Enlever l'option d'interaction
        IInteractable i = other?.GetComponent<IInteractable>();
        if(i == interactable)
        {
            interactable = null;
        }        
    }
    */

    private void RaycastDetection()
    {
        //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * detectionRange);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Envoi du ray
        if(Physics.Raycast(ray, out RaycastHit hit, detectionRange))
        {
            IInteractable i = hit.collider.GetComponent<IInteractable>();
            if(i != null)
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
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
