using Cinemachine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunnerControllerStateMachine : BaseStateMachine<RunnerState>
{
    [field: SerializeField]
    public Animator Animator { get; private set; }

    [field: SerializeField] 
    public Rigidbody RB { get; private set; }

    public Vector2 m_input;
    public Vector3 m_direction;

    [SerializeField]
    public float m_speed;

    [SerializeField]
    public float m_smoothTime = 0.05f;
    public float m_currentVelocity;

    public float m_velocity;

    #region Jump Variables
    [SerializeField]
    public float m_jumpIntensity;
    public bool m_isJumping = false;
    #endregion

    #region Sprint Variables
    [SerializeField]
    public float m_sprintMultiplier = 2.0f;
    [SerializeField]
    public float m_maxEnergyAmount = 3f;
    public float m_energyAmount;
    public bool m_isSprinting = false;
    #endregion

    #region Dead Variables
    public bool m_isAlive = true;
    #endregion
    public bool m_isWalking = false;


    [SerializeField]
    public Transform cam;

    [SerializeField]
    private RunnerGroundTrigger m_groundTrigger;

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<RunnerState>();
        m_possibleStates.Add(new FreeState());
        m_possibleStates.Add(new SprintState());
        m_possibleStates.Add(new JumpState());
        m_possibleStates.Add(new DoubleJumpState());
        m_possibleStates.Add(new FallingState());
        m_possibleStates.Add(new RollState());
        m_possibleStates.Add(new DeadState());
    }

    protected override void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (RunnerState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();
    }

    protected override void Update()
    {
        base.Update();

        UpdateAnimatorValues();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void UpdateAnimatorValues()
    {
        Animator.SetFloat("Horizontal", m_input.x) ;
        Animator.SetFloat("Vertical", m_input.y);
        Animator.SetBool("TouchGround", IsInContactWithGround());
    }

    public void Move(InputAction.CallbackContext context)
    {
        m_input = context.ReadValue<Vector2>();
        m_direction = new Vector3(m_input.x, 0f, m_input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsInContactWithGround()) return;

        if (m_currentState is FreeState)
        {
            m_isJumping = true;
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (m_currentState is FreeState)
            {
                m_isSprinting = true;
            }
        }
        else if (context.canceled)
        {
            m_isSprinting = false;
        }
    }

    public void ApplyMovement()
    {
        Vector3 inputDirection = m_direction;
        if (m_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        var angle = Mathf.SmoothDampAngle(RB.rotation.eulerAngles.y, targetAngle, ref m_currentVelocity, m_smoothTime);

        Quaternion targetRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        RB.MoveRotation(targetRotation);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        RB.velocity = moveDirection.normalized * m_speed;
    }

    public bool IsInContactWithGround()
    {
        return m_groundTrigger.IsOnGround;
    }

}
