using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : NetworkBehaviour
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
    private TextMeshProUGUI m_playerName;
    [SerializeField]
    private TextMeshProUGUI m_IpAdress;
    
    [SerializeField]
    private GameObject m_UIPlayerName;
    [SerializeField]
    private GameObject m_UIPlayerNameAnchor;

    string m_userName;
    string m_LobbyIp;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        m_networkManagerRef = GetComponent<NetworkRoomManager>();
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
        
        if(isClient)
        {
            InstantiateUserName();
        }
       
    }


    

    public void PlayerUserName()
    { 
        m_userName = m_playerName.text;
        Debug.Log(m_userName);
    }
    public void PlayerIp()
    {
        m_LobbyIp = m_IpAdress.text;
    }

    public void HostGame()
    {
        m_networkManagerRef.StartHost();
        GoToMultiplayerLobby();

    }

    public void JoinGame()
    {
        m_startMenu.SetActive(false);
        m_networkManagerRef.StartClient();
        m_networkManagerRef.networkAddress = m_LobbyIp;
        GoToMultiplayerLobby();       
    }
    
    [Command(requiresAuthority = false)]
    private void InstantiateUserName()
    {
        CreateUserName(m_userName);
        Debug.Log(m_userName);
    }

    [ClientRpc]
    private void CreateUserName(string username)
    {
        m_UIPlayerName.GetComponent<TextMeshProUGUI>().text = username;
        Debug.Log(username);
        Instantiate(m_UIPlayerName, m_UIPlayerNameAnchor.transform);
    }
}
