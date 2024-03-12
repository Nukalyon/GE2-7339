using UnityEngine;

public class ChaseState : IState
{
    private AIController aiController;

    private Transform cible;

    public ChaseState(AIController aiController)
    {
        this.aiController = aiController;
    }
    
    public void Enter()
    {
        cible = aiController.GetCible();
        aiController.SetAnimation("Chase");
    }

    public void Execute()
    {
        aiController.SetDestinationToCible();
    }

    public void Exit()
    {
        
    }
}
