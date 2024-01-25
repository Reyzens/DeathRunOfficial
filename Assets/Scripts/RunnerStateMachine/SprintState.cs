using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : RunnerState
{
    private const float STATE_EXIT_TIMER = 3f;
    private float m_currentStateTimer;
    public override void OnEnter()
    {
        m_stateMachine.m_speed *= m_stateMachine.m_sprintMultiplier;
        m_currentStateTimer = STATE_EXIT_TIMER;
        Debug.Log("Enter state: SprintState\n");
    }

    public override void OnFixedUpdate()
    {
        m_stateMachine.ApplyMovement();
    }

    public override void OnUpdate()
    {
        m_currentStateTimer -= Time.deltaTime;
    }

    public override void OnExit()
    {
        m_stateMachine.m_isSprinting = false;
        m_stateMachine.m_speed /= m_stateMachine.m_sprintMultiplier;
        Debug.Log("Exit state: SprintState\n");
    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isSprinting;
    }

    public override bool CanExit()
    {
        return m_currentStateTimer <= 0;
    }
}
