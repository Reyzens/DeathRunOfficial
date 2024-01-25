using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGroundTrigger : MonoBehaviour
{
    public bool IsOnGround { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (!IsOnGround)
        {
            Debug.Log("Runner is on ground");
        }
        IsOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Runner just quit ground");
        IsOnGround = false;
    }
}
