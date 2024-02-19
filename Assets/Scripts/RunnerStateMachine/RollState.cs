using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : RunnerState
{
    Vector3 m_startPosition;
    Vector3 m_endPosition;
    private const float STATE_EXIT_TIMER = 0.55f;
    private float m_currentStateTimer;
    float m_startTime;
    float m_duration;
    public override void OnEnter()
    {
        Debug.Log("Enter state: RollState");
        m_stateMachine.Animator.SetBool("Rolling", true);
        m_stateMachine.m_isRolling = false;

        m_stateMachine.m_energyAmount -= m_stateMachine.m_energyRollCost;

        m_startPosition = m_stateMachine.transform.position;
        m_endPosition = m_stateMachine.transform.position + m_stateMachine.transform.forward * m_stateMachine.m_rollDistance;
        m_startTime = Time.time;
        m_duration = m_stateMachine.m_rollDistance / m_stateMachine.m_rollSpeed;

        m_stateMachine.Collider.height = m_stateMachine.m_crouchHeight;
        m_stateMachine.Collider.center = new Vector3(m_stateMachine.Collider.center.x, m_stateMachine.m_crouchCenterY, m_stateMachine.Collider.center.z);
        m_currentStateTimer = STATE_EXIT_TIMER;

        m_stateMachine.m_isInvicible = true;
    }

    public override void OnExit()
    {
        m_stateMachine.m_isRolling = false;
        m_stateMachine.Animator.SetBool("Rolling", false);

        m_stateMachine.Collider.height = m_stateMachine.m_originalHeight;
        m_stateMachine.Collider.center = new Vector3(m_stateMachine.Collider.center.x, m_stateMachine.m_originalCenterY, m_stateMachine.Collider.center.z);

        m_stateMachine.m_isInvicible = false;
    }

    public override void OnFixedUpdate()
    {
        float elapsedTime = Time.time - m_startTime;
        if (elapsedTime < m_duration)
        {
            float progress = elapsedTime / m_duration;
            Vector3 newPosition = Vector3.Lerp(m_startPosition, m_endPosition, progress);

            Vector3 velocity = (newPosition - m_stateMachine.transform.position) / Time.fixedDeltaTime;

            m_stateMachine.RB.velocity = velocity;
        }
        else
        {
            m_stateMachine.RB.velocity = Vector3.zero;
        }

    }

    public override void OnUpdate()
    {
        m_currentStateTimer -= Time.deltaTime;
    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isRolling;
    }

    public override bool CanExit()
    {
        return m_currentStateTimer <= 0;
    }
}
