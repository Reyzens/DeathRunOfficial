using Mirror;
using UnityEngine;
using static LobbymanagerSimplePO;

public class LobbyLinker : MonoBehaviour
{
    [SerializeField]
    private LobbymanagerSimplePO m_lobby;
    [SerializeField]
    private NetworkRoomPlayer m_player;
    [SerializeField]
    private ETeam m_chooseTeam;
    [SerializeField]
    private GameObject m_selectedTeam;
    [SerializeField]
    private string m_username;
    [SerializeField]
    private string m_ipAdress;
    [SerializeField]
    private string m_port;

    // Start is called before the first frame update
    void Start()
    {
        m_lobby = GameObject.Find("LobbyManager").GetComponent<LobbymanagerSimplePO>();
        m_player = GetComponent<NetworkRoomPlayer>();

        if (m_player.isLocalPlayer)
        {
            m_lobby.SetPlayer(ref m_player);
            m_lobby.SetLobbyLinker(gameObject.GetComponent<LobbyLinker>());
            m_username = m_lobby.m_username;
            m_ipAdress = m_lobby.m_lobbyIp;
            m_port = m_lobby.m_port;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTeamSelection(ETeam newTeam, GameObject prefab)
    {
        m_chooseTeam = newTeam;
        GetComponent<NetworkRoomPlayer>().SetPlayerRole((int)newTeam);
    }

    public ETeam GetChosenTeam()
    {
        return m_chooseTeam;
    }

    public void SetRole(GameObject role)
    {
        GetComponent<NetworkRoomPlayer>().m_playerInGamePrefab = role;
        //m_selectedTeam = Instantiate(role, transform);
    }

    public void SetUsername(string name)
    {
        m_username = name;
    }
    public string GetUsername()
    {
        return m_username;
    }
    public void SetIpAdress(string IpAdress)
    {
        m_ipAdress = IpAdress;
    }
    public string GetIpAdress()
    {
        return m_ipAdress;
    }
    public void SetPort(string Port)
    {
        m_port = Port;
    }
    public string GetPort()
    {
        return m_port;
    }
}
