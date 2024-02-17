using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with DeadTrigger");

            Transform playerTransform = collision.gameObject.transform;
            if (playerTransform != null)
            {
                RunnerControllerStateMachine runnerStateMachine = playerTransform.GetComponent<RunnerControllerStateMachine>();

                if (runnerStateMachine != null)
                {
                    if (!runnerStateMachine.m_isInvicible)
                    {
                        runnerStateMachine.m_isAlive = false;
                        Debug.Log("Set m_isAlive to false");
                    }
                }
            }
        }
    }

}