using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : RunnerState
{
    private const float STATE_EXIT_TIMER = 0.2f;
    private float m_currentStateTimer;
    public override void OnEnter()
    {
        Debug.Log("Enter state: JumpingState");
        m_stateMachine.Animator.SetTrigger("Jump");

        Vector3 jumpForce = Vector3.up * m_stateMachine.m_jumpIntensity;
        if (m_stateMachine.m_wasSprintingBeforeJump)
        {
            jumpForce += Vector3.up * m_stateMachine.m_sprintJumpBonus;
        }

        m_stateMachine.RB.AddForce(jumpForce, ForceMode.Impulse);

        m_stateMachine.m_wasSprintingBeforeJump = false;

        m_stateMachine.m_numberOfJump++;
        m_currentStateTimer = STATE_EXIT_TIMER;
    }


    public override void OnExit()
    {
        Debug.Log("Exit state: JumpingState");
        m_stateMachine.m_isJumping = false;
        m_stateMachine.Animator.SetBool("Sprinting", false);
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
        return m_stateMachine.m_isJumping;
    }

    public override bool CanExit()
    {
        return (m_currentStateTimer <= 0 && m_stateMachine.IsInContactWithGround()) || m_stateMachine.m_isDoubleJumping;
    }
}
