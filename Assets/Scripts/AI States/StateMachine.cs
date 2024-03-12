public class StateMachine
{
    private IState currentState;
    
    public StateMachine(IState initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    public void SetState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void ExecuteState()
    {
        currentState?.Execute();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }

    
}
