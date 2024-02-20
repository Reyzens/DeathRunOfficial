using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;

public class NetworkRunner : NetworkBehaviour
{
    public PlayerInput playerInput;
    public RunnerControllerStateMachine controllerStateMachine;
    public Transform cameraTarget;
    public GameObject thirdPersonCameraPrefab;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("OnStartLocalPlayer called.");
        playerInput.enabled = true;
        controllerStateMachine.enabled = true;

        GameObject cameraInstance = Instantiate(thirdPersonCameraPrefab, transform, transform);

        CameraSetup(cameraInstance);
    }

    private void CameraSetup(GameObject cameraInstance)
    {
        cameraInstance.GetComponent<CinemachineFreeLook>().Follow = cameraTarget;
        cameraInstance.GetComponent<CinemachineFreeLook>().LookAt = cameraTarget;
    }
}
