using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPLayerInfo : MonoBehaviour
{
    public enum playerTeam
    {
        Hunter,
        Runner,
        count
    }
    [Serializable]
    struct PlayerInfo
    {
        [SerializeField]
        private string m_playerName;
        private bool m_BTNisReady;
        private playerTeam m_playerTeam;


        public void SetUserName(string userName)
        {
            m_playerName = userName;
        }

        public void SetPlayerTeam(playerTeam team)
        {
            m_playerTeam = team;
        }

        public void SetIsReady(bool isReady)
        {
            m_BTNisReady = isReady;
        }
    }
}
