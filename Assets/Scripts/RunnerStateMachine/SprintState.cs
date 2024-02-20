using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : RunnerState
{
    public override void OnEnter()
    {
        Debug.Log("Enter state: SprintState\n");
        m_stateMachine.m_speed *= m_stateMachine.m_sprintMultiplier;
        m_stateMachine.Animator.SetBool("Sprinting", true);
    }

    public override void OnFixedUpdate()
    {
        m_stateMachine.ApplyMovement();
    }

    public override void OnUpdate()
    {
        m_stateMachine.ReduceStamina(Time.deltaTime);
    }
    public override void OnExit()
    {
        Debug.Log("Exit state: SprintState\n");
        m_stateMachine.Animator.SetBool("Sprinting", false);
        m_stateMachine.m_isSprinting = false;
        m_stateMachine.m_speed /= m_stateMachine.m_sprintMultiplier;
    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isSprinting && m_stateMachine.m_energyAmount > 0f;
    }

    public override bool CanExit()
    {
        return m_stateMachine.m_energyAmount <= 0 || m_stateMachine.m_isSprinting == false || m_stateMachine.m_isJumping || m_stateMachine.m_isRolling;
    }
}
