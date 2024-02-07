using UnityEngine;
using Cinemachine;

public class HunterCameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Speed of the camera movement")]
    private float speed = 1f;

    private CinemachinePathBase pathBase;
    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            pathBase = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path;
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