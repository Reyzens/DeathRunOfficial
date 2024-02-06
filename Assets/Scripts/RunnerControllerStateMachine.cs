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

    public float m_speed;

    public float m_smoothTime = 0.05f;
    public float m_currentVelocity;

    #region Jump Variables
    public float m_jumpIntensity = 65f;
    public bool m_isJumping = false;
    public bool m_isDoubleJumping = false;
    public int m_maxNumberOfJumps = 2;
    public int m_numberOfJump = 0;
    public float m_forwardJumpMultiplier = 0.2f;
    public float m_sprintJumpBonus = 10f;
    public bool m_wasSprintingBeforeJump = false;
    #endregion

    #region Sprint Variables
    public float m_sprintMultiplier = 2.0f;
    public float m_maxEnergyAmount = 3f;
    public float m_energyAmount;
    public bool m_isSprinting = false;
    #endregion

    #region Dead Variables
    public bool m_isAlive = true;
    #endregion

    #region Crouch Variables
    public bool m_isCrouching = false;
    #endregion

    #region Roll Variables
    public bool m_isRolling = false;
    #endregion

    public bool m_isWalking = false;
    public bool m_isFalling = false;


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
        m_possibleStates.Add(new CrouchState());
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

        if (m_currentState is JumpState)
        {
            m_isDoubleJumping = true;
        }

        if (!IsInContactWithGround()) return;

        if (m_currentState is FreeState)
        {
            m_isJumping = true;
        }
        else if (m_currentState is SprintState)
        {
            m_isJumping = true;
            m_wasSprintingBeforeJump = true;
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
            Animator.SetBool("Sprinting", false);
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsInContactWithGround()) return;

        if (m_currentState is FreeState)
        {
            m_isCrouching = true;
        }
        else if (m_currentState is SprintState)
        {
            m_isRolling = true;
        }
        else if (m_currentState is CrouchState)
        {
            m_isCrouching = false;
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

        float yVelocity = RB.velocity.y;
        Vector3 horizontalVelocity = moveDirection.normalized * m_speed;


        RB.velocity = new Vector3(horizontalVelocity.x, yVelocity, horizontalVelocity.z);
    }

    public bool IsInContactWithGround()
    {
        return m_groundTrigger.IsOnGround;
    }

}
