using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NetworkRunner : NetworkBehaviour
{
    public PlayerInput playerInput;
    public RunnerControllerStateMachine controllerStateMachine;
    public Transform cameraTarget;
    public GameObject localRunnerPrefab;
    private EnergyUIManager energyUIManager;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("OnStartLocalPlayer called.");
        playerInput.enabled = true;
        controllerStateMachine.enabled = true;

        GameObject localRunnerInstance = Instantiate(localRunnerPrefab, transform.position, transform.rotation);
        Transform thirdPersonCameraTransform = localRunnerInstance.transform.Find("ThirdPersonCamera");
        energyUIManager = FindObjectOfType<EnergyUIManager>();

        CameraSetup(thirdPersonCameraTransform.gameObject);
    }

    private void CameraSetup(GameObject cameraInstance)
    {
        cameraInstance.GetComponent<CinemachineFreeLook>().Follow = cameraTarget;
        cameraInstance.GetComponent<CinemachineFreeLook>().LookAt = cameraTarget;
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

        if (energyUIManager != null)
        {
            Debug.Log("In UpdateUI Stamina");
            energyUIManager.UpdateStamina(staminaValue); // Assuming this method exists in your UI manager
        }
    }
}
