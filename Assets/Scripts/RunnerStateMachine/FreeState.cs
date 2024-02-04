using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeState : RunnerState
{
    public override void OnEnter()
    {
        Debug.Log("Enter state: FreeState\n");
    }

    public override void OnFixedUpdate()
    {
        m_stateMachine.ApplyMovement();
    }

    public override void OnUpdate()
    {
        if (m_stateMachine.m_energyAmount < m_stateMachine.m_maxEnergyAmount)
            m_stateMachine.m_energyAmount += Time.deltaTime;
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: FreeState\n");
    }

    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.IsInContactWithGround();
    }

    public override bool CanExit()
    {
        return true;
    }
}
