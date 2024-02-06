using UnityEngine;

public class MapRotator : MonoBehaviour
{
    [SerializeField]
    private float m_timeBeforeMaxStrength;
    [SerializeField]
    private float m_rotationSpeed;
    [SerializeField]
    private float m_max_rotation;

    private float m_currentRotationTime = 0.0f;
    private float m_speedIncreaseRatio;
    private float m_currentRotationStrength = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_speedIncreaseRatio = m_rotationSpeed / m_timeBeforeMaxStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            CommandActivatedEffect(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CommandActivatedEffect(Vector3.forward * -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CommandActivatedEffect(Vector3.right * -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CommandActivatedEffect(Vector3.right);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ResetRotationValue();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ResetRotationValue();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ResetRotationValue();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ResetRotationValue();
        }
    }

    private void ResetRotationValue()
    {
        m_currentRotationStrength = 0.0f;
    }

    private void CommandActivatedEffect(Vector3 direction)
    {
        Debug.Log(m_currentRotationStrength);
        m_currentRotationStrength = Mathf.Min(m_currentRotationStrength + m_speedIncreaseRatio * Time.deltaTime, m_rotationSpeed);
        transform.Rotate(direction * m_currentRotationStrength * Time.deltaTime);
    }
}
