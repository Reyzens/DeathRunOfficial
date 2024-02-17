using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : RunnerState
{

    public override void OnEnter()
    {
        Debug.Log("Enter state: CrouchState");
        m_stateMachine.m_speed *= m_stateMachine.m_crouchMultiplier;
        m_stateMachine.Animator.SetBool("Crouching", true);

        m_stateMachine.Collider.height = m_stateMachine.m_crouchHeight;
        m_stateMachine.Collider.center = new Vector3(m_stateMachine.Collider.center.x, m_stateMachine.m_crouchCenterY, m_stateMachine.Collider.center.z);
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: CrouchState");
        m_stateMachine.Animator.SetBool("Crouching", false);
        m_stateMachine.m_isCrouching = false;
        m_stateMachine.m_speed /= m_stateMachine.m_crouchMultiplier;

        m_stateMachine.Collider.height = m_stateMachine.m_originalHeight;
        m_stateMachine.Collider.center = new Vector3(m_stateMachine.Collider.center.x, m_stateMachine.m_originalCenterY, m_stateMachine.Collider.center.z);
    }

    public override void OnFixedUpdate()
    {
        m_stateMachine.ApplyMovement();
    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isCrouching;
    }

    public override bool CanExit()
    {
        return !m_stateMachine.m_isCrouching;
    }
}
