using Game.Floor.Cristal;
using UnityEngine;
using Zenject;

namespace Game.Floor
{
    public class FlorInstaller : ScriptableObjectInstaller<FlorInstaller>
    {
        [SerializeField] private FlorController florController;
        [SerializeField] private CristalController cristalController;
        [SerializeField] private CristalBody cristalBody;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FlorController>()
                .FromComponentInNewPrefab(florController)
                .WithGameObjectName("FlorMain")
                .AsSingle()
                .NonLazy();
            Container.BindInterfacesAndSelfTo<CristalController>()
                .FromComponentInNewPrefab(cristalController)
                .WithGameObjectName("Cristal")
                .AsSingle()
                .NonLazy();

            Container.Bind<CristalBody>().FromInstance(cristalBody).AsTransient();

            Container.DeclareSignal<CristalColisionSignal>().OptionalSubscriber();
            Container.DeclareSignal<SegmentMovingSignal>().OptionalSubscriber();
        }
    }
}