using UnityEngine;
using Zenject;

namespace GameSystem.Installers
{
    public class ObjectSelectorInstaller : MonoInstaller
    {
        [SerializeField] private ObjectSelector objectSelector;
        [SerializeField] private Transform coreModulesHolder;
        public override void InstallBindings()
        {
            var objectSelectorInstance = Container.InstantiatePrefabForComponent<ObjectSelector>(objectSelector, Vector3.zero, Quaternion.identity, coreModulesHolder);
            Container.Bind<ObjectSelector>().FromInstance(objectSelectorInstance).AsSingle().NonLazy();
        }
    }
}
