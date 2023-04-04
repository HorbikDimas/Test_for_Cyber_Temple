using Game.Balls.Camera;
using Game.Balls.Input;
using Game.Balls.Moving;
using UnityEngine;
using Zenject;

namespace Game.Balls
{
    public class BallsInstaller : ScriptableObjectInstaller<BallsInstaller>
    {
        [SerializeField] private BallCamera ballCamera;

        [SerializeField] private Ball ball;

        public override void InstallBindings()
        {
            BindCamera();
            BindBall();
            
        }

        private void BindCamera()
        {
            Container.BindInterfacesAndSelfTo<BallCamera>()
                .FromComponentInNewPrefab(ballCamera)
                .WithGameObjectName("CameraMain")
                .AsSingle()
                .NonLazy();
        }

        private void BindBall()
        {
            Container.BindInterfacesAndSelfTo<Ball>()
                .FromComponentInNewPrefab(ball)
                .WithGameObjectName("Ball")
                .AsSingle()
                .NonLazy();
        }
    }
}