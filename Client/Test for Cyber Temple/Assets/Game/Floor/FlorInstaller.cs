using UnityEngine;
using Zenject;

namespace Game.Floor
{
    public class FlorInstaller : ScriptableObjectInstaller<FlorInstaller>
    {
        [SerializeField] private FlorController florController;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FlorController>()
                .FromComponentInNewPrefab(florController)
                .WithGameObjectName("FlorMain")
                .AsSingle()
                .NonLazy();
        }
    }
}