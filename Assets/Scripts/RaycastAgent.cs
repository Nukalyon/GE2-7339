using UnityEngine;
using UnityEngine.AI;

public class RaycastAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public void Start()
    {
        agent.SetDestination(Vector3.zero);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

}
