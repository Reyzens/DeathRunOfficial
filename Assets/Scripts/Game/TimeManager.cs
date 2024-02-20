using Mirror;
using TMPro;
using UnityEngine;

public class TimeManager : NetworkBehaviour
{
    [SerializeField]
    private float m_GameDuration;
    [SerializeField]
    private TextMeshProUGUI m_clockText;
    [SerializeField]
    private GameObject m_hunterWinPanel;
    [SerializeField]
    private GameObject m_runnerWinPanel;
    [SerializeField]
    private GameObject m_playAgainBTN;
    [SerializeField]
    private GameObject m_winCanvas;

    [SerializeField]
    [SyncVar(hook = nameof(OnRunnerWonChanged))]
    private bool m_runnerWon = false;

    [SerializeField]
    private GameObject m_winPanel;

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
                    HunterWin();
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

    [ClientRpc]
    private void HunterWin()
    {
        if (!m_runnerWon)
        {
            m_winPanel.SetActive(true);
            m_hunterWinPanel.SetActive(true);
            m_playAgainBTN.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            m_winCanvas.GetComponent<Canvas>().sortingOrder = 10;
        }
    }

    private void OnRunnerWonChanged(bool oldValue, bool newValue)
    {
        if (newValue)
        {
            // If runnerWon is now true, perform actions for when the runner wins.
            m_winPanel.SetActive(true);
            m_runnerWinPanel.SetActive(true);
            m_playAgainBTN.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            m_winCanvas.GetComponent<Canvas>().sortingOrder = 10;
        }
    }

    [Command(requiresAuthority = false)]
    public void RunnerWin()
    {
        m_runnerWon = true;
    }
    public void OnPlayAgainBTN()
    {


        //if (isClient)
        //{
        //    NetworkManager.singleton.StopClient();
        //}
        //if (isServer)
        //{
        //    NetworkManager.singleton.StopHost();
        //}

        //Destroy(GameObject.Find("NetworkManager"));

        //foreach (GameObject roomPlayer in GameObject.FindObjectsOfType<GameObject>())
        //{
        //    if (roomPlayer.name == "SimpleRoomPlayer(Clone)")
        //    {
        //        Destroy(roomPlayer);
        //    }
        //}

        //SceneManager.LoadScene("LobbyTest2PO");

    }
}