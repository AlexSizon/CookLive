using System;
using Equipment.Enums;
using MiniGames.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
    public abstract class MiniGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private Button closeButton;
        public CanvasGroup FailedPanel;
        public Button FailedButton;
        public QteType MiniGameType;

        private void Start()
        {
            closeButton.onClick.AddListener(() => Destroy(this.gameObject));
            FailedButton.onClick.AddListener(() =>
            {
                FailedPanel.alpha = 0;
                FailedPanel.interactable = false;
                FailedPanel.blocksRaycasts = false;
                Destroy(this.gameObject);
            });
        }

        public abstract void StartGame();
        public abstract void GetMiniGameResult();

        public abstract void ResetGame();

        public void MiniGameFailed()
        {
            ResetGame();
            FailedPanel.alpha = 1;
            FailedPanel.interactable = true;
            FailedPanel.blocksRaycasts = true;
        }
    }
}