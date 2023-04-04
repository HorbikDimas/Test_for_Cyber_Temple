using Game.Scenes.Common;
using Zenject;

namespace Game.Scenes
{
    public class SceneInstaller : ScriptableObjectInstaller<SceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScenesController>().AsSingle();
            
            Container.DeclareSignal<SceneLoadingSignal>().OptionalSubscriber();
            Container.DeclareSignal<RoundFinishedSignal>().OptionalSubscriber();
            Container.DeclareSignal<StartRoundSignal>().OptionalSubscriber();
        }
    }
}