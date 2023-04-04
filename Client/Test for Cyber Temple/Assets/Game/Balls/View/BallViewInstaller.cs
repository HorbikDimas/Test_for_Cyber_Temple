using UnityEngine;
using Zenject;

namespace Game.Balls.View
{
    public class BallViewInstaller : ScriptableObjectInstaller<BallViewInstaller>
    {
        [SerializeField]
        private BallModels ballModels = null;
        public override void InstallBindings()
        {
            Container.BindInstance(ballModels);
        }
    }
}