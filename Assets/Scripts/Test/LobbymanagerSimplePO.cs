using Mirror;
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
    [SerializeField]
    private PanelManager teamSelectionManager;

    public void OnHostClick()
    {
        isHost = true;
        manager.StartHost();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
        ReadyBottunUI.SetActive(false);
    }

    public void OnJoinClick()
    {
        isHost = false;
        manager.StartClient();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
        ReadyBottunUI.SetActive(false);
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
        switch (m_chooseTeam)
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
        ReadyBottunUI.SetActive(false);
        cancelReadyBtn.SetActive(true);
    }

    public void OnCancelClick()
    {
        player.CmdChangeReadyState(false);
        ReadyBottunUI.SetActive(true);
        cancelReadyBtn.SetActive(false);
    }

    public void OnHunterClick()
    {
        Debug.Log("Hunter click");
        ReadyBottunUI.SetActive(true);
        teamSelectionManager.ChangePlayerTeam((int)ETeam.Hunter, m_username);
        lobbyLinker.OnTeamSelection(ETeam.Hunter, hunterPrefab);
        m_chooseTeam = ETeam.Hunter;
        //if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Hunter, hunterPrefab);
        //    m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_hunterPanelRef.transform, false);
        //    m_playerButtonUI.name = m_username;
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //    m_chooseTeam = ETeam.Hunter;

        //    hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        //}
        //else
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Hunter, hunterPrefab);
        //    m_playerButtonUI.transform.SetParent(m_hunterPanelRef.transform, false);
        //    m_chooseTeam = ETeam.Hunter;
        //}
    }
    //readyPanel.SetActive(true);

    public void OnChoosingClick()
    {
        ReadyBottunUI.SetActive(false);
        cancelReadyBtn.SetActive(false);
        player.CmdChangeReadyState(false);
        Debug.Log("Waiting click");
        teamSelectionManager.ChangePlayerTeam((int)ETeam.Count, m_username);
        lobbyLinker.OnTeamSelection(ETeam.Count, hunterPrefab);
        m_chooseTeam = ETeam.Count;
        //if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Count, hunterPrefab);
        //    m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_waitingPanelRef.transform, false);
        //    m_playerButtonUI.name = m_username;
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //    m_chooseTeam = ETeam.Count;

        //    hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        //}
        //else
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Count, hunterPrefab);
        //    m_playerButtonUI.transform.SetParent(m_waitingPanelRef.transform, false);
        //    m_chooseTeam = ETeam.Count;
        //}
    }


    public void OnRunnerClick()
    {
        Debug.Log("Runner click");
        ReadyBottunUI.SetActive(true);
        teamSelectionManager.ChangePlayerTeam((int)ETeam.Runner, m_username);
        lobbyLinker.OnTeamSelection(ETeam.Runner, runnerPrefab);
        m_chooseTeam = ETeam.Runner;
        //if (!hunterUIInstantiated) // Check if UI hasn't been instantiated yet
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Runner, runnerPrefab);
        //    m_playerButtonUI = Instantiate(m_lobbyPlayerPrefabUI, m_runnerPanelRef.transform, false);
        //    m_playerButtonUI.name = m_username;
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetName(m_username);
        //    m_playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //    m_chooseTeam = ETeam.Runner;

        //    hunterUIInstantiated = true; // Set flag to true to indicate UI instantiation
        //}
        //else
        //{
        //    lobbyLinker.OnTeamSelection(ETeam.Runner, runnerPrefab);
        //    m_playerButtonUI.transform.SetParent(m_runnerPanelRef.transform, false);
        //    m_chooseTeam = ETeam.Runner;
        //}
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
