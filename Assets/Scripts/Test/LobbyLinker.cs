using Mirror;
using UnityEngine;
using static LobbymanagerSimplePO;

public class LobbyLinker : MonoBehaviour
{
    [SerializeField]
    private LobbymanagerSimplePO lobby;
    [SerializeField]
    private NetworkRoomPlayer player;
    [SerializeField]
    private ETeam chosenTeam;
    [SerializeField]
    private GameObject selectedRole;

    // Start is called before the first frame update
    void Start()
    {
        lobby = GameObject.Find("LobbyManager").GetComponent<LobbymanagerSimplePO>();
        player = GetComponent<NetworkRoomPlayer>();

        lobby.SetPlayer(ref player);
        lobby.SetLobbyLinker(gameObject.GetComponent<LobbyLinker>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTeamSelection(ETeam newTeam)
    {
        chosenTeam = newTeam;
    }

    public ETeam GetChosenTeam()
    {
        return chosenTeam;
    }

    public void SetRole(GameObject role)
    {
        selectedRole = role;
    }
}
