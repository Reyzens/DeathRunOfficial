using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : RunnerState
{
    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter(IState currentState)
    {
        return false;
    }

    public override bool CanExit()
    {
        return false;
    }
}
