using Mirror;
using UnityEngine;

public class InfoGathering : NetworkBehaviour
{
    [SerializeField]
    private int m_playerIndex;
    [SerializeField]
    private LobbyManagerPO m_manager;
    [SerializeField]
    private LocalPlayerInfoPO m_localPlayerInfo;
    // Start is called before the first frame update

    void Start()
    {
        m_manager = GameObject.Find("LobbyManager").GetComponent<LobbyManagerPO>();
        m_localPlayerInfo = GameObject.Find("LocalPlayerInfo").GetComponent<LocalPlayerInfoPO>();
        OnStartInfoGathering();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Command(requiresAuthority = false)]
    void OnStartInfoGathering()
    {
        UpdateIndex();
    }

    [ClientRpc]
    void UpdateIndex() { m_playerIndex = GetComponent<RoomPlayerPO>().index; }
}
