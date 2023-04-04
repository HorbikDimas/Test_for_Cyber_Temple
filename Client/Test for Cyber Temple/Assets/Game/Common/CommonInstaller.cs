using Zenject;

namespace Game.Common
{
    public class CommonInstaller : ScriptableObjectInstaller<CommonInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        }
    }
}