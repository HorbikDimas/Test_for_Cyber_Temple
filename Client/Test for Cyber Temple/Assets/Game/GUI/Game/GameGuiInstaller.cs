using Game.GUI.Game.Main;
using UnityEngine;
using Zenject;

namespace Game.GUI.Game
{
    public class GameGuiInstaller : ScriptableObjectInstaller<GameGuiInstaller>
    {
        [SerializeField] private MainGameView _mainGameView;
        public override void InstallBindings()
        {
            Container.Bind<MainGameView>()
                .FromComponentInNewPrefab(_mainGameView)
                .WithGameObjectName("GameUI")
                .AsSingle()
                .NonLazy();
            Container.DeclareSignal<ButtonClickedSignal>().OptionalSubscriber();
        }
    }
}