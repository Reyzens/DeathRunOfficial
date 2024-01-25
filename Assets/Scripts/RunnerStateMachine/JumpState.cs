using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : RunnerState
{
    private const float STATE_EXIT_TIMER = 0.2f;
    private float m_currentStateTimer;
    public override void OnEnter()
    {
        Debug.Log("Exit state: JumpingState");
        m_stateMachine.RB.AddForce(Vector3.up * m_stateMachine.m_jumpIntensity, ForceMode.Acceleration);
        m_currentStateTimer = STATE_EXIT_TIMER;
        m_stateMachine.Animator.SetTrigger("Jump");
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: JumpingState");
        m_stateMachine.m_isJumping = false;
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
        return m_stateMachine.m_isJumping;
    }

    public override bool CanExit()
    {
        return m_stateMachine.IsInContactWithGround() && m_currentStateTimer <= 0;
    }
}
