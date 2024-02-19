using UnityEngine;
using Cinemachine;

public class HunterCameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Speed of the camera movement")]
    private float speed = 1f;

    private CinemachinePathBase pathBase;
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private Transform m_followCamera;
    [SerializeField]
    private Transform m_LookAtCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            pathBase = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path;
            m_LookAtCamera = GameObject.Find("Plane").transform;
            m_followCamera = GameObject.Find("Plane").transform;
            virtualCamera.LookAt = m_LookAtCamera;
            virtualCamera.Follow = m_followCamera;
        }
    }

    private void Update()
    {
        if (pathBase != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition -= speed * Time.deltaTime;
                Debug.Log("left");
            }
            else if (Input.GetKey(KeyCode.X))
            {
                virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += speed * Time.deltaTime;
                Debug.Log("right");
            }
        }
    }
}