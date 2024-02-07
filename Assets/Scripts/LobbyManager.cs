using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_startMenu;
    [SerializeField]
    private GameObject m_lobbySelection;
    [SerializeField]
    private TextMeshProUGUI m_playerName;
    [SerializeField]
    private GameObject m_teamSelection;

    string m_userName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLobbySelection()
    {
        m_startMenu.SetActive(false);
        m_lobbySelection.SetActive(true);
        m_teamSelection.SetActive(false);
    }

    public void GoToTeamSelection()
    {
        m_startMenu.SetActive(false);
        m_lobbySelection.SetActive(false);
        m_teamSelection.SetActive(true);
    }

    public void GoToStart()
    {
        m_startMenu.SetActive(true);
        m_lobbySelection.SetActive(false);
        m_teamSelection.SetActive(false);
    }

    public void PlayerUserName()
    { 
        m_userName = m_playerName.text;
        Debug.Log(m_userName);
    }
}
