using Mirror;
using UnityEngine;

public class TrapDoorController : NetworkBehaviour
{
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_rotationAngle;
    [SerializeField]
    private float m_rotationTime;

    private float m_currentRotationTime = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) && m_currentRotationTime < 0)
        {
            m_currentRotationTime = m_rotationTime;
        }
    }

    private void FixedUpdate()
    {
        if (m_currentRotationTime > 0)
        {
            m_currentRotationTime -= Time.fixedDeltaTime;
            ActivatedEffect();
        }
    }

    [ClientRpc]
    void ActivatedEffect()
    {
        transform.RotateAround(transform.position, Vector3.up, m_rotationAngle * (m_speed * Time.fixedDeltaTime));
    }
}
