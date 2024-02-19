using Mirror;
using Mirror.Examples.Basic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbymanagerSimplePO : MonoBehaviour
{
    [SerializeField]
    NetworkRoomManager manager;
    [SerializeField]
    private bool isHost;
    [SerializeField]
    private GameObject hostJoinPanel;
    [SerializeField]
    private GameObject ReadyBottunUI;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject readyBtn;
    [SerializeField]
    private GameObject startGameBtn;
    [SerializeField]
    private GameObject cancelReadyBtn;
    [SerializeField]
    private NetworkRoomPlayer player;
    [SerializeField]
    private LobbyLinker lobbyLinker;
    [SerializeField]
    private GameObject teamSelectionPanel;
    [SerializeField]
    private GameObject hunterPrefab;
    [SerializeField]
    private GameObject runnerPrefab;
    [SerializeField]
    private TextMeshProUGUI m_playername;
    [SerializeField]
    private TextMeshProUGUI m_ipAdress;
    [SerializeField]
    private TextMeshProUGUI m_playerPort;
    [SerializeField]
    private GameObject m_lobbyPlayerPrefabUI;
    [SerializeField]
    private GameObject m_hunterPanelRef;
    [SerializeField]
    private GameObject m_waitingPanelRef;
    [SerializeField]
    private GameObject m_runnerPanelRef;
    [SerializeField]
    private List<NetworkRoomPlayer> playerList = new List<NetworkRoomPlayer>();
    [SerializeField]
    private List<LobbyLinker> lobbyLinkerList = new List<LobbyLinker>();

    [SerializeField]
    public string m_username;
    [SerializeField]
    public string m_lobbyIp;
    [SerializeField]
    public string m_port;
    [SerializeField]
    private bool hunterUIInstantiated = false;
    [SerializeField]
    private GameObject m_playerButtonUI;
    [SerializeField]
    private ETeam m_chooseTeam;

    public void OnHostClick()
    {
        isHost = true;
        manager.StartHost();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
        ReadyBottunUI.SetActive(true);



    }

    public void OnJoinClick()
    {
        isHost = false;
        manager.StartClient();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
        ReadyBottunUI.SetActive(true);
    }

    public void SetPlayer(ref NetworkRoomPlayer newPlayer)
    {
        //playerList.Add(newPlayer);
        player = newPlayer;
    }

    public void SetLobbyLinker(LobbyLinker linker)
    {
        //lobbyLinkerList.Add(linker);
        lobbyLinker = linker;
    }
    public void OnReadyClick()
    {
        switch (lobbyLinker.GetChosenTeam())
        {
            case ETeam.Hunter:
                lobbyLinker.SetRole(hunterPrefab);
                break;
            case ETeam.Runner:
                lobbyLinker.SetRole(runnerPrefab);
                break;
            case ETeam.Count:
                break;
        }
        player.CmdChangeReadyState(true);
        readyBtn.SetActive(false);
        cancelReadyBtn.SetActive(true);
    }

    public void OnCancelClick()
    {
        player.CmdChangeReadyState(false);
        readyBtn.SetActive(true);
        cancelReadyBtn.SetActive(false);
    }

    public void OnHunterClick()
    {
        if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        {
            lobbyLinker.OnTeamSelection(ETeam.Hunter,hunterPrefab);
            m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_hunterPanelRef.transform, false);
            m_playerButtonUI.name = m_username;
            m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
            m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
            m_chooseTeam = ETeam.Hunter;    

            hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        }
        else
        {
            lobbyLinker.OnTeamSelection(ETeam.Hunter,hunterPrefab);
            m_playerButtonUI.transform.SetParent(m_hunterPanelRef.transform, false);
            m_chooseTeam = ETeam.Hunter;
        }
    }
    //readyPanel.SetActive(true);
    public void OnChoosingClick()
    {
        if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        {
            lobbyLinker.OnTeamSelection(ETeam.Count,hunterPrefab);
            m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_waitingPanelRef.transform, false);
            m_playerButtonUI.name = m_username;
            m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
            m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
            m_chooseTeam = ETeam.Count; 

            hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        }
        else
        {
            lobbyLinker.OnTeamSelection(ETeam.Count, hunterPrefab);
            m_playerButtonUI.transform.SetParent(m_waitingPanelRef.transform, false);
            m_chooseTeam = ETeam.Count;
        }
        readyPanel.SetActive(false);
    }

    public void OnRunnerClick()
    {
        if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        {
            lobbyLinker.OnTeamSelection(ETeam.Runner, runnerPrefab);
            m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_runnerPanelRef.transform, false);
            m_playerButtonUI.name = m_username;
            m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
            m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
            m_chooseTeam = ETeam.Runner;

            hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        }
        else
        {
            lobbyLinker.OnTeamSelection(ETeam.Runner, runnerPrefab);
            m_playerButtonUI.transform.SetParent(m_runnerPanelRef.transform, false);
            m_chooseTeam = ETeam.Runner;
        }
    }

    public enum ETeam
    {
        Hunter,
        Runner,
        Count
    }

    public void OnPlayerNameInput()
    {
        m_username = m_playername.text;      
    }

    public void OnPlayerIpInput()
    {
        m_lobbyIp = m_ipAdress.text;
    }

    public void OnPlayerPortInput()
    { 
        m_port = m_playerPort.text;
    }
}
