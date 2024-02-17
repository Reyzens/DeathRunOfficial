using UnityEngine;

public class MultiplayerPanel : MonoBehaviour
{
    [SerializeField]
    private LobbyManagerPO m_lobbyManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Debug.Log("multiplayerpanel enabled");
        m_lobbyManager.JoinWaitingTeamBTN();
    }
}
