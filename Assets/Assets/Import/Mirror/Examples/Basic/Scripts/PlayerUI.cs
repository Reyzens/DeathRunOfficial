﻿using Mirror.Examples.MultipleMatch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Examples.Basic
{
    public class PlayerUI : MonoBehaviour
    {
        [Header("Player Components")]
        public Button m_playerButtonUI;

        [Header("Child Text Objects")]
        public TextMeshProUGUI m_playerUserName;

        public MonoBehaviour m_playerInfoScript;

        private void Start()
        {
            
        }
        
        // Sets a highlight color for the local player
        public void SetLocalPlayer()
        {
            // add a visual background for the local player in the UI
            //image.color = new Color(1f, 1f, 1f, 0.1f);
        }

        // This value can change as clients leave and join
        public void OnPlayerNumberChanged(byte newPlayerNumber)
        {
            //playerNameText.text = string.Format("Player {0:00}", newPlayerNumber);
        }

        // Random color set by Player::OnStartServer
        public void OnPlayerColorChanged(Color32 newPlayerColor)
        {
            //playerNameText.color = newPlayerColor;
        }

        // This updates from Player::UpdateData via InvokeRepeating on server
        public void OnPlayerDataChanged(ushort newPlayerData)
        {
            // Show the data in the UI
            //playerDataText.text = string.Format("Data: {0:000}", newPlayerData);
        }
    }
}