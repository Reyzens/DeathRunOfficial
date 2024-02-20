using UnityEngine;

public class RunnerWinBox : MonoBehaviour
{
    [SerializeField]
    private TimeManager m_timeManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerRunnerWin();
        }
    }

    private void TriggerRunnerWin()
    {
        m_timeManager.RunnerWin();
    }
}
