using Mirror;
using TMPro;
using UnityEngine;

public class TimeManager : NetworkBehaviour
{
    [SerializeField]
    private float m_GameDuration;
    [SerializeField]
    private TextMeshProUGUI m_clockText;
    [SyncVar(hook = nameof(OnTimeLeftChanged))]
    private float m_timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            m_timeLeft = m_GameDuration;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (m_timeLeft > 0)
            {
                m_timeLeft -= Time.deltaTime;
            }
            else
            {
                // Ensure we only call this once by checking if m_timeLeft has not been set to a negative value already
                if (m_timeLeft != -1)
                {
                    //NetworkManager.singleton.KickAllPlayers();
                    m_timeLeft = -1; // Prevent multiple scene changes
                }
            }
        }
    }

    private void OnTimeLeftChanged(float oldTime, float newTime)
    {
        // Update the UI element on all clients
        if (m_clockText != null)
        {
            m_clockText.text = $"Time left: {Mathf.Max(0, newTime):0.00}";
        }
    }
}