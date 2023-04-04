using Zenject;

namespace Game.Settings
{
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSettings>()
                .AsSingle();
        }
    }
}