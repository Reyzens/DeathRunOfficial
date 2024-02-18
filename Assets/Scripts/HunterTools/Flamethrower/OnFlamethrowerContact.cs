using UnityEngine;

public class OnFlamethrowerContact : MonoBehaviour
{
    private RunnerControllerStateMachine m_runnerStateMachine;
    private void Start()
    {
        m_runnerStateMachine = GetComponent<RunnerControllerStateMachine>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collididng wth flame");
        if (other.CompareTag("DeathTrap"))
        {
            Debug.Log("Player collided with DeadTrigger");


            if (!m_runnerStateMachine.m_isInvicible)
            {
                m_runnerStateMachine.m_isAlive = false;
                Debug.Log("Set m_isAlive to false");
            }
        }
    }
}
