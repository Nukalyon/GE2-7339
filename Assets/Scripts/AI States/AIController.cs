using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    private StateMachine stateMachine;

    [Header("Attack Parameters")] 
    public int attackDamage;
    [Space(10)]
    public float attackCooldown;
    
    [ReadOnly] public float attackCooldownActuel = 0;

    [Header("Chase Parameters")] 
    [Range(0, 50), Tooltip("Le vitesse de base pour chase")] public float chaseSpeed;
    
    [Header("Idle Parameters")]
    public float idleTime;

    private bool isActive = true;
    private Transform cible;

    void Start()
    {
        stateMachine = new StateMachine(new ChaseState(this));
    }

    void Update()
    {
        if (!isActive) return;
        
        //stateMachine.ExecuteState();
        //HandleTransitions();

        attackCooldownActuel += Time.deltaTime;
    }

    private void HandleTransitions()
    {
        IState currentState = stateMachine.GetCurrentState();
        switch (currentState)
        {
            case ChaseState:
                if (cible == null)
                {
                    stateMachine.SetState(new IdleState(this));
                }
                else if (Vector3.Distance(this.transform.position, cible.transform.position) < 2)
                {
                    stateMachine.SetState(new AttackState(this));
                }
                break;
            case IdleState:
                if (cible != null)
                {
                    stateMachine.SetState(new ChaseState(this));
                }
                break;
        }
        
    }

    public void SetDestinationToCible()
    {
        navMeshAgent.SetDestination(cible.position);
    }
    
    public Transform GetCible()
    {
        return cible;
    }

    public void SetAnimation(string animationState)
    {
        animator.Play(animationState);
    }
}
