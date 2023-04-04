using Zenject;

namespace Game.Scenes
{
    public class SceneInstaller : ScriptableObjectInstaller<SceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneController>().AsSingle();
        }
    }
}