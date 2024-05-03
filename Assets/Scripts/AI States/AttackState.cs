using System.Collections;

public class AttackState : IState
{
    private AIController aiController;

    public AttackState(AIController aiController)
    {
        this.aiController = aiController;
    }
    
    public void Enter()
    {
        aiController.SetAnimation("Attack");
    }

    public void Execute()
    {
        //Attack!
    }

    public void Exit()
    {
        
    }
}

