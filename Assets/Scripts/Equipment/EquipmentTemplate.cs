using System;
using System.Collections.Generic;
using Equipment.Enums;
using Equipment.Interfaces;
using InteractableObjects.Interfaces;
using MiniGames;
using UnityEngine;
using Zenject;

namespace Equipment
{
    public abstract class EquipmentTemplate : MonoBehaviour, IInteractable, IEquipment
    {
        [SerializeField] private QteType qteType;
        [SerializeField] private List<GameObject> equipmentPrefabsList;
        [SerializeField] private Transform equipmentSpawnPoint;
        private int equipmentLevel = 1;
        private MiniGamesPool miniGamesPool;

        [Inject]
        private void Construct(MiniGamesPool miniGamesPool)
        {
            this.miniGamesPool = miniGamesPool;
        }

        private void Start()
        {
            //Instantiate(equipmentPrefabsList[equipmentLevel], equipmentSpawnPoint);
        }

        public void Interact()
        {
            StartMiniGame(qteType);
        }

        private void StartMiniGame(QteType miniGameType)
        {
            miniGamesPool.StartMiniGameByType(miniGameType);
        }
    }
}