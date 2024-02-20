using Mirror;
using TMPro;
using UnityEngine;

public class TimeManager : NetworkBehaviour
{
    [SerializeField]
    private float m_GameDuration;
    [SerializeField]
    private TextMeshProUGUI m_clockText;
    [SyncVar]
    private float m_timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        m_clockText.text = GetComponent<TextMeshProUGUI>().text;
        if (isServer) { m_timeLeft = m_GameDuration; }

    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            m_timeLeft -= Time.deltaTime;
            m_clockText.text = "Time left : " + (m_GameDuration + m_timeLeft);
        }
    }
}
