using UnityEngine;

public class MapRotator : MonoBehaviour
{
    [SerializeField]
    private float m_timeBeforeMaxStrength;
    [SerializeField]
    private float m_rotationSpeed;
    [SerializeField]
    private float m_max_rotation;

    private float m_speedIncreaseRatio;

    private float m_currentRotationStrengthUp = 0.0f;
    private float m_currentRotationStrengthDown = 0.0f;
    private float m_currentRotationStrengthRight = 0.0f;
    private float m_currentRotationStrengthLeft = 0.0f;

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
            CommandActivatedEffect(Vector3.forward, ref m_currentRotationStrengthUp);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CommandActivatedEffect(Vector3.forward * -1, ref m_currentRotationStrengthDown);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CommandActivatedEffect(Vector3.right * -1, ref m_currentRotationStrengthLeft);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CommandActivatedEffect(Vector3.right, ref m_currentRotationStrengthRight);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            m_currentRotationStrengthUp = 0.0f; ;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            m_currentRotationStrengthDown = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_currentRotationStrengthRight = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_currentRotationStrengthLeft = 0.0f;
        }
    }
    private float NormalizeAngle(float angle)
    {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }

    private void CommandActivatedEffect(Vector3 direction, ref float currentRotationStrength)
    {
        //Debug.Log(m_currentRotationStrength);

        //Predict current tilt
        float predictedCurrentStrength = Mathf.Min(currentRotationStrength + m_speedIncreaseRatio * Time.deltaTime, m_rotationSpeed) * Time.deltaTime;
        Quaternion predictedRotation = Quaternion.Euler(transform.eulerAngles + direction * predictedCurrentStrength);
        Vector3 predictedAngle = predictedRotation.eulerAngles;

        float normalizedX = NormalizeAngle(predictedAngle.x);
        float normalizedZ = NormalizeAngle(predictedAngle.z);

        if (Mathf.Abs(normalizedX) < m_max_rotation && Mathf.Abs(normalizedZ) < m_max_rotation)
        {
            currentRotationStrength = Mathf.Min(currentRotationStrength + m_speedIncreaseRatio * Time.deltaTime, m_rotationSpeed);
            transform.Rotate(direction * currentRotationStrength * Time.deltaTime);
        }
    }
}
