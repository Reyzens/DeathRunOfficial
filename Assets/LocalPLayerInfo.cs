using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalPlayerInfo : MonoBehaviour
{
    
    public enum playerTeam
    {
        Hunter,
        Runner,
        count
    }

    [SerializeField]
    private string m_playerName;
    [SerializeField]
    private bool m_ButtonIsReady;
    [SerializeField]
    private playerTeam m_playerTeam;
    [SerializeField]
    private TextMeshProUGUI m_playerNameText;



    void Start()
    {
        m_playerName = GameObject.Find("LobbyManager").GetComponent<LobbyManager>().m_playerName.text;
    }

    public void SetUserName()
    {
        m_playerName = m_playerNameText.text;
    }

    public void SetPlayerTeam(playerTeam team)
    {
        m_playerTeam = team;
    }

    public void SetIsReady(bool isReady)
    {
        m_ButtonIsReady = isReady;
    }
}
