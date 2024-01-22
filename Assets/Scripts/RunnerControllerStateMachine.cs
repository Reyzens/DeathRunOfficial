using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class RunnerControllerStateMachine : BaseStateMachine<RunnerState>
{
    public Transform Camera { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public Animator Animator { get; private set; }

    protected override void CreatePossibleStates()
    {

    }

    protected override void Start()
    {
        foreach (RunnerState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();

        //Camera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();

        //UpdateAnimatorValues();
    }

    protected override void FixedUpdate()
    {
        //SetDirectionalInputs();
        //base.FixedUpdate();
        //Set2dRelativeVelocity();
    }

    //public bool IsInContactWithFloor()
    //{
    //    return m_floorTrigger.IsOnFloor;
    //}

    //private void UpdateAnimatorValues()
    //{
    //    //Aller chercher ma vitesse actuelle
    //    //Communiquer directement avec mon Animator

    //    Animator.SetFloat("MoveX", CurrentRelativeVelocity.x / GetCurrentMaxSpeed());
    //    Animator.SetFloat("MoveY", CurrentRelativeVelocity.y / GetCurrentMaxSpeed());
    //    Animator.SetBool("TouchGround", m_floorTrigger.IsOnFloor);
    //}

    //private void Set2dRelativeVelocity()
    //{
    //    Vector3 relativeVelocity = RB.transform.InverseTransformDirection(RB.velocity);

    //    CurrentRelativeVelocity = new Vector2(relativeVelocity.x, relativeVelocity.z);
    //}

}
