using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpState : RunnerState
{
    private const float STATE_EXIT_TIMER = 0.2f;
    private float m_currentStateTimer;
    public override void OnEnter()
    {
        Debug.Log("Enter state: DoubleJumpState");
        m_currentStateTimer = STATE_EXIT_TIMER;
        m_stateMachine.Animator.SetTrigger("DoubleJump");

        Vector3 jumpForce = Vector3.up * m_stateMachine.m_jumpIntensity;

        m_stateMachine.RB.AddForce(jumpForce, ForceMode.Impulse);

        m_stateMachine.ReduceStamina(m_stateMachine.m_doubleJumpCost);

        m_stateMachine.m_numberOfJump++;
    }


    public override void OnExit()
    {
        m_stateMachine.m_isDoubleJumping = false;
        m_stateMachine.m_numberOfJump = 0;
        Debug.Log("Exit state: DoubleJumpState");
    }

    public override void OnFixedUpdate()
    {
        m_stateMachine.ApplyMovement();
    }

    public override void OnUpdate()
    {
        m_currentStateTimer -= Time.deltaTime;
    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isDoubleJumping;
    }

    public override bool CanExit()
    {
        return m_currentStateTimer <= 0 && m_stateMachine.IsInContactWithGround();
    }
}
