using MiniGames;
using UnityEngine;
using Zenject;

namespace GameSystem.Installers
{
    public class MiniGamesPoolInstaller : MonoInstaller
    {
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private MiniGamesPool miniGamesPoolPrefab;
        [SerializeField] private Transform coreModulesHolder;

        public override void InstallBindings()
        {
            var miniGamesPoolPrefabInstance =
                Container.InstantiatePrefabForComponent<MiniGamesPool>(miniGamesPoolPrefab, Vector3.zero,
                    Quaternion.identity, coreModulesHolder);
            miniGamesPoolPrefabInstance.MainCanvas = mainCanvas;
            Container.Bind<MiniGamesPool>().FromInstance(miniGamesPoolPrefabInstance).AsSingle().NonLazy();
        }
    }
}