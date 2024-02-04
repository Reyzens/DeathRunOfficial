using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : RunnerState
{
    private const float STATE_EXIT_TIMER = 1.5f;
    private float m_currentStateTimer;
    public override void OnEnter()
    {
        Debug.Log("Exit state: DeadState");
        m_currentStateTimer = STATE_EXIT_TIMER;
        m_stateMachine.Animator.SetTrigger("Dead");
        m_stateMachine.Animator.SetBool("Alive", false);
    }

    public override void OnExit()
    {
        m_stateMachine.Animator.SetBool("Alive", true);
        m_stateMachine.m_isAlive = true;
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        m_currentStateTimer -= Time.deltaTime;
    }

    public override bool CanEnter(IState currentState)
    {
        return !m_stateMachine.m_isAlive;
    }

    public override bool CanExit()
    {
        return m_currentStateTimer <= 0;
    }
}
