using System;
using System.Collections.Generic;
using System.Linq;
using Equipment.Enums;
using MiniGames.Interfaces;
using UnityEngine;

namespace MiniGames
{
    public class MiniGamesPool : MonoBehaviour
    {
        [SerializeField] private List<MiniGame> miniGames;
        private Canvas mainCanvas;

        public Canvas MainCanvas
        {
            get => mainCanvas;
            set => mainCanvas = value;
        }


        public void StartMiniGameByType(QteType type)
        {
            var selectedMiniGame = miniGames.FirstOrDefault(x => x.MiniGameType == type);
            var instantiatedMiniGame = Instantiate(selectedMiniGame, mainCanvas.transform);
            instantiatedMiniGame.StartGame();
        }
    }
}