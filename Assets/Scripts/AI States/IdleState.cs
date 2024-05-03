public class IdleState : IState
{
    private AIController aiController;
    
    public IdleState(AIController aiController)
    {
        this.aiController = aiController;
    }
    
    public void Enter()
    {
        aiController.SetAnimation("Idle");
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
