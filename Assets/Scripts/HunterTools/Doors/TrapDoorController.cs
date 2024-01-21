using UnityEngine;

public class TrapDoorController : MonoBehaviour
{

    float m_speed = 10.0f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);
    }
}
