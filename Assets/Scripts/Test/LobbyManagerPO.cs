using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManagerPO : NetworkBehaviour
{
    [SerializeField]
    private NetworkRoomManager m_networkManagerRef;


    [SerializeField]
    private GameObject m_startMenu;
    [SerializeField]
    private GameObject m_lobbySelection;
    [SerializeField]
    private GameObject m_multiplayerLobby;
    [SerializeField]
    private LocalPlayerInfoPO m_localPlayer;
    [SerializeField]
    private GameObject m_playerTag;
    [SerializeField]
    private Transform m_waitingListParent;
    [SerializeField]
    private Transform m_hunterListParent;
    [SerializeField]
    private Transform m_runnerListParent;

    public List<GameObject> m_hunterList = new List<GameObject>();
    [SyncVar(hook = nameof(UpdateWaitingList))]
    public List<GameObject> m_waitingList = new List<GameObject>();
    public List<GameObject> m_runnerList = new List<GameObject>();


    string m_LobbyIp;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        //m_networkManagerRef = GetComponent<NetworkRoomManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void GoToStart()
    {
        m_startMenu.SetActive(true);
        m_lobbySelection.SetActive(false);
        m_multiplayerLobby.SetActive(false);
    }
    public void GoToLobbySelection()
    {
        m_startMenu.SetActive(false);
        m_lobbySelection.SetActive(true);
        m_multiplayerLobby.SetActive(false);
    }

    public void GoToMultiplayerLobby()
    {
        m_startMenu.SetActive(false);
        m_lobbySelection.SetActive(false);
        m_multiplayerLobby.SetActive(true);

    }
    public void PlayerIsReadyBTN()
    {
        m_networkManagerRef.roomPlayerPrefab.CmdChangeReadyState(true);
    }

    public void JoinHunterTeamBTN()
    {
        //m_networkManagerRef.roomPlayerPrefab.OnHunterTeamBTN();
    }
    public void JoinRunnerTeamBTN()
    {
        //m_networkManagerRef.roomPlayerPrefab.OnRunnerTeamBTN();
    }

    public void JoinWaitingTeamBTN()
    {
        UpdateWaitingTeam(m_localPlayer.GetLocalUsername());
    }

    public void UpdateWaitingTeam(string username)
    {
        Debug.Log("Join waiting team");
        if (m_waitingList.Count == 0)
        {
            Debug.Log("Instantiate playerTag");
            GameObject newPlayerTag = Instantiate(m_playerTag, m_waitingListParent);
            newPlayerTag.GetComponent<PlayerTag>().SetUsername(username);
            NetworkServer.Spawn(newPlayerTag);
            m_waitingList.Add(newPlayerTag);
        }
        foreach (GameObject playerTag in m_waitingList)
        {
            if (playerTag.GetComponent<PlayerTag>().CompareUserame(username))
            {
                return;
            }
            else
            {
                Debug.Log("Instantiate playerTag");
                GameObject newPlayerTag = Instantiate(m_playerTag, m_waitingListParent);
                newPlayerTag.GetComponent<PlayerTag>().SetUsername(username);
                NetworkServer.Spawn(newPlayerTag);
                m_waitingList.Add(newPlayerTag);
            }
        }
    }

    public void UpdateWaitingList(List<GameObject> oldList, List<GameObject> newList)
    {
        Debug.Log("Syncvar of waiting list");
        foreach (GameObject playerTag in newList)
        {
            bool isNew = true;
            foreach (GameObject comparedPlayerTag in oldList)
            {
                if (playerTag.GetComponent<PlayerTag>().CompareTag(comparedPlayerTag.GetComponent<PlayerTag>().GetUsername()))
                {
                    isNew = false;
                }
            }

            if (isNew)
            {
                GameObject newPlayerTag = Instantiate(playerTag, m_waitingListParent);
            }
        }
    }

    public void HostGame()
    {
        Debug.Log("Try to call starthost");
        m_networkManagerRef.StartHost();
        GoToMultiplayerLobby();
    }

    public void JoinGame()
    {
        m_startMenu.SetActive(false);
        m_networkManagerRef.StartClient();
        //m_networkManagerRef.networkAddress = m_LobbyIp;
        GoToMultiplayerLobby();
    }


}
