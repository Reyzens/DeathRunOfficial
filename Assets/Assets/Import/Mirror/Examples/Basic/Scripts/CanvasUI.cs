using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Examples.Basic
{
    public class CanvasUI : MonoBehaviour
    {
        [Tooltip("Assign Main Panel so it can be turned on from Player:OnStartClient")]
        public RectTransform mainPanel;

        [Tooltip("Assign Players Panel for instantiating PlayerUI as child")]
        public RectTransform playersPanel;

        public RectTransform HunterPanel;
        public RectTransform RunnerPanel;
        public RectTransform WaitingPanel;

        public Button JoinHunterButton;
        public Button JoinRunnerButton;
        public Button JoinWaintingButton;
        public Button StartButton;
        public Button ReadyButton;

        // static instance that can be referenced from static methods below.
        static CanvasUI instance;

        void Awake()
        {
            instance = this;
        }

        public static void SetActive(bool active)
        {
            instance.WaitingPanel.gameObject.SetActive(active);
        }

        public static RectTransform GetPlayersPanel() => instance.WaitingPanel;
    }
}
