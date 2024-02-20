using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NetworkRunner : NetworkBehaviour
{
    public PlayerInput m_playerInput;
    public RunnerControllerStateMachine m_controllerStateMachine;
    public Transform m_cameraTarget;
    public GameObject m_localRunnerPrefab;
    private EnergyUIManager m_energyUIManager;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("OnStartLocalPlayer called.");
        m_playerInput.enabled = true;
        m_controllerStateMachine.enabled = true;

        GameObject localRunnerInstance = Instantiate(m_localRunnerPrefab, transform.position, transform.rotation);
        Transform thirdPersonCameraTransform = localRunnerInstance.transform.Find("ThirdPersonCamera");
        m_energyUIManager = FindObjectOfType<EnergyUIManager>();

        CameraSetup(thirdPersonCameraTransform.gameObject);
    }

    private void CameraSetup(GameObject cameraInstance)
    {
        cameraInstance.GetComponent<CinemachineFreeLook>().Follow = m_cameraTarget;
        cameraInstance.GetComponent<CinemachineFreeLook>().LookAt = m_cameraTarget;
    }

    public void RequestStaminaUpdate(float stamina)
    {
        if (isLocalPlayer)
        {
            Debug.Log("In Request StaminaUpdate");
            UpdateStaminaUI(stamina);
        }
    }

    // Updates the UI with the new stamina value
    private void UpdateStaminaUI(float staminaValue)
    {
        Debug.Log("YEWWWWHASsdfsdfsdfsfsf");

        if (m_energyUIManager != null)
        {
            Debug.Log("In UpdateUI Stamina");
            m_energyUIManager.UpdateStamina(staminaValue); // Assuming this method exists in your UI manager
        }
    }
}
