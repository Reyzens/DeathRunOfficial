using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoGather : MonoBehaviour
{
    [SerializeField]
    public GameObject m_playerInfoUI;
    [SerializeField]
    public enum Playerteam
    {
        Hunter,
        Runner,
        Waiting
    }
    [SerializeField]
    private Playerteam m_playerTeam;
    [SerializeField]
    private string m_userName;
    [SerializeField]
    private bool m_isReady;


}
