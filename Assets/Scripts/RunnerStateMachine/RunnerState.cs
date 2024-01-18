public abstract class RunnerState : IState
{
    protected RunnerControllerStateMachine m_stateMachine;

    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnStart(RunnerControllerStateMachine stateMachineRef)
    {
        m_stateMachine = stateMachineRef;
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnFixedUpdate()
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual bool CanEnter(IState currentState)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool CanExit()
    {
        throw new System.NotImplementedException();
    }
}
