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
    private List<NetworkRoomPlayer> playerList = new List<NetworkRoomPlayer>();
    [SerializeField]
    private List<LobbyLinker> lobbyLinkerList = new List<LobbyLinker>();

    [SerializeField]
    public string m_username;
    [SerializeField]
    public string m_lobbyIp;
    [SerializeField]
    public string m_port;

    public void OnHostClick()
    {
        isHost = true;
        manager.StartHost();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
        

    }

    public void OnJoinClick()
    {
        isHost = false;
        manager.StartClient();
        hostJoinPanel.SetActive(false);
        teamSelectionPanel.SetActive(true);
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
        lobbyLinker.OnTeamSelection(ETeam.Hunter);
        readyPanel.SetActive(true);
    }

    public void OnChoosingClick()
    {
        lobbyLinker.OnTeamSelection(ETeam.Count);
        readyPanel.SetActive(false);
    }

    public void OnRunnerClick()
    {
        lobbyLinker.OnTeamSelection(ETeam.Runner);
        readyPanel.SetActive(true);
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
