using Player;
using UnityEngine;
using Zenject;

namespace GameSystem.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerUnit playerPrefab;
        [SerializeField] private Transform spawnPoint;

        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerUnit>(playerPrefab, spawnPoint.position, Quaternion.identity, null);
            Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle().NonLazy();
        }
    }
}