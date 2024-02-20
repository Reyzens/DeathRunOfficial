using Mirror;
using Mirror.Examples.Basic;
using UnityEngine;

public class PanelManager : NetworkBehaviour
{
    [SerializeField]
    private GameObject hunterPanel;
    [SerializeField]
    private GameObject waitingPanel;
    [SerializeField]
    private GameObject runnerPanel;

    private int hunterTeam = 0;
    private int runnerTeam = 1;
    private int waitingTeam = 2;

    //[SerializeField]
    //[SyncVar]
    //private List<string> hunterList = new List<string>();
    //[SerializeField]
    //[SyncVar]
    //private List<string> waitingList = new List<string>();
    //[SerializeField]
    //[SyncVar]
    //private List<string> runnerList = new List<string>();

    public SyncList<string> hunterList = new SyncList<string>();
    public SyncList<string> waitingList = new SyncList<string>();
    public SyncList<string> runnerList = new SyncList<string>();

    [SerializeField]
    private GameObject m_playerButtonUIPrefab;

    void Start()
    {

    }

    private void Update()
    {
        if (hunterPanel != null && hunterPanel.gameObject.scene.name == "LobbyTest2PO")
        {
            Debug.Log("Should enter update");
            PlayerUICheck();
        }
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        hunterList.Callback += OnHunterListChanged;
        runnerList.Callback += OnRunnerListChanged;
        waitingList.Callback += OnWaitingListChanged;
    }
    private void OnHunterListChanged(SyncList<string>.Operation op, int index, string oldItem, string newItem)
    {
        if (op == SyncList<string>.Operation.OP_ADD)
        {
            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, hunterPanel.transform, false);
            playerButtonUI.name = newItem;
            playerButtonUI.GetComponent<PlayerUI>().SetName(newItem);
            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        }
        else if (op == SyncList<string>.Operation.OP_REMOVEAT)
        {
            DeletePlayerUI(oldItem);
        }
    }

    private void OnRunnerListChanged(SyncList<string>.Operation op, int index, string oldItem, string newItem)
    {
        if (op == SyncList<string>.Operation.OP_ADD)
        {
            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, runnerPanel.transform, false);
            playerButtonUI.name = newItem;
            playerButtonUI.GetComponent<PlayerUI>().SetName(newItem);
            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        }
        else if (op == SyncList<string>.Operation.OP_REMOVEAT)
        {
            DeletePlayerUI(oldItem);
        }
    }

    private void OnWaitingListChanged(SyncList<string>.Operation op, int index, string oldItem, string newItem)
    {
        if (op == SyncList<string>.Operation.OP_ADD)
        {
            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, waitingPanel.transform, false);
            playerButtonUI.name = newItem;
            playerButtonUI.GetComponent<PlayerUI>().SetName(newItem);
            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        }
        else if (op == SyncList<string>.Operation.OP_REMOVEAT)
        {
            DeletePlayerUI(oldItem);
        }
    }

    private void PlayerUICheck()
    {
        //if (isClient)
        //{
        //    foreach (string username in hunterList)
        //    {
        //        if (GameObject.Find(username) == null)
        //        {
        //            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, hunterPanel.transform, false);
        //            playerButtonUI.name = username;
        //            playerButtonUI.GetComponent<PlayerUI>().SetName(username);
        //            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //        }
        //        else if (GameObject.Find(username).transform.parent == hunterPanel.transform)
        //        {
        //            GameObject.Find(username).transform.SetParent(hunterPanel.transform);
        //        }
        //    }

        //    foreach (string username in runnerList)
        //    {
        //        if (GameObject.Find(username) == null)
        //        {
        //            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, runnerPanel.transform, false);
        //            playerButtonUI.name = username;
        //            playerButtonUI.GetComponent<PlayerUI>().SetName(username);
        //            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //        }
        //        else if (GameObject.Find(username).transform.parent == runnerPanel.transform)
        //        {
        //            GameObject.Find(username).transform.SetParent(runnerPanel.transform);
        //        }
        //    }

        //    foreach (string username in waitingList)
        //    {
        //        if (GameObject.Find(username) == null)
        //        {
        //            GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, waitingPanel.transform, false);
        //            playerButtonUI.name = username;
        //            playerButtonUI.GetComponent<PlayerUI>().SetName(username);
        //            playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
        //        }
        //        else if (GameObject.Find(username).transform.parent == waitingPanel.transform)
        //        {
        //            GameObject.Find(username).transform.SetParent(waitingPanel.transform);
        //        }
        //    }
        //}

        if (isClient)
        {
            Debug.Log("PlayerUIUpdate update");
            foreach (string username in hunterList)
            {
                Debug.Log("Found " + username);
                if (GameObject.Find(username) != null)
                {
                    GameObject.Find(username).transform.SetParent(hunterPanel.transform, false);
                }
                if (GameObject.Find(username) == null)
                {
                    GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, hunterPanel.transform, false);
                    playerButtonUI.name = username;
                    playerButtonUI.GetComponent<PlayerUI>().SetName(username);
                    playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
                }
            }
            foreach (string username in runnerList)
            {
                if (GameObject.Find(username) != null)
                {
                    GameObject.Find(username).transform.SetParent(runnerPanel.transform, false);
                }
                if (GameObject.Find(username) == null)
                {
                    GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, runnerPanel.transform, false);
                    playerButtonUI.name = username;
                    playerButtonUI.GetComponent<PlayerUI>().SetName(username);
                    playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
                }
            }
            foreach (string username in waitingList)
            {
                if (GameObject.Find(username) != null)
                {
                    GameObject.Find(username).transform.SetParent(waitingPanel.transform, false);

                }
                if (GameObject.Find(username) == null)
                {
                    GameObject playerButtonUI = Instantiate(m_playerButtonUIPrefab, waitingPanel.transform, false);
                    playerButtonUI.name = username;
                    playerButtonUI.GetComponent<PlayerUI>().SetName(username);
                    playerButtonUI.GetComponent<PlayerUI>().SetLocalPlayer();
                }
            }
        }
    }

    [Command(requiresAuthority = false)]
    public void ChangePlayerTeam(int team, string username)
    {
        Debug.Log("Enter changeplayerteam");
        switch (team)
        {
            //Hunter
            case 0:
                AddUserToList(hunterTeam, username);
                break;
            //Runner
            case 1:
                AddUserToList(runnerTeam, username);
                break;
            //Waiting
            case 2:
                AddUserToList(waitingTeam, username);
                break;
            default: break;
        }
    }

    private void AddUserToList(int team, string username)
    {
        if (isServer)
        {
            switch (team)
            {
                //Hunter
                case 0:
                    CheckIfOtherListCountain(team, username);
                    if (!hunterList.Contains(username))
                    {
                        hunterList.Add(username);
                    }
                    break;
                //Runner
                case 1:
                    CheckIfOtherListCountain(team, username);
                    if (!runnerList.Contains(username))
                    {
                        runnerList.Add(username);
                    }
                    break;
                //Waiting
                case 2:
                    CheckIfOtherListCountain(team, username);
                    if (!waitingList.Contains(username))
                    {
                        waitingList.Add(username);
                    }
                    break;
                default: break;
            }
        }
    }

    private void CheckIfOtherListCountain(int team, string username)
    {
        switch (team)
        {
            //Hunter
            case 0:
                if (runnerList.Contains(username))
                {
                    DeleteFromList(runnerTeam, username);
                }
                else if (waitingList.Contains(username))
                {
                    DeleteFromList(waitingTeam, username);
                }
                break;
            //Runner
            case 1:
                if (hunterList.Contains(username))
                {
                    DeleteFromList(hunterTeam, username);
                }
                else if (waitingList.Contains(username))
                {
                    DeleteFromList(waitingTeam, username);
                }
                break;
            //Waiting
            case 2:
                if (runnerList.Contains(username))
                {
                    DeleteFromList(runnerTeam, username);
                }
                else if (hunterList.Contains(username))
                {
                    DeleteFromList(hunterTeam, username);
                }
                break;
            default: break;
        }
    }

    private void DeleteFromList(int team, string username)
    {
        switch (team)
        {
            //Hunter
            case 0:
                hunterList.Remove(username);
                break;
            //Runner
            case 1:
                runnerList.Remove(username);
                break;
            //Waiting
            case 2:
                waitingList.Remove(username);
                break;
            default:
                break;
        }
    }

    [ClientRpc]
    private void DeletePlayerUI(string username)
    {
        Destroy(GameObject.Find(username));
    }
}
