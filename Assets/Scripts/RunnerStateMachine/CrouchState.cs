using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : RunnerState
{
    public override void OnEnter()
    {
        Debug.Log("Enter state: FallingState");
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: FallingState");
    }

    public override void OnFixedUpdate()
    {
        ApplyInAirMovement();
    }

    public override void OnUpdate()
    {

    }

    private void ApplyInAirMovement()
    {
        Vector3 inputDirection = m_stateMachine.m_direction;
        if (m_stateMachine.m_input.sqrMagnitude == 0) return;

        Vector3 moveDirection = new Vector3(inputDirection.x, 0f, inputDirection.y).normalized;
        Vector3 force = moveDirection * m_stateMachine.m_speed * Time.fixedDeltaTime;
        m_stateMachine.RB.AddForce(force, ForceMode.VelocityChange);
    }

    public override bool CanEnter(IState currentState)
    {
        return !m_stateMachine.IsInContactWithGround();
    }

    public override bool CanExit()
    {
        return true;
    }
}
