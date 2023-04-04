using Game.GUI.Game.Main;
using Game.GUI.Game.Menu;
using Game.GUI.Game.Round;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.GUI.Game
{
    public class GameGuiInstaller : ScriptableObjectInstaller<GameGuiInstaller>
    {
        [SerializeField] private MainGameView mainView;
        [SerializeField] private RoundGameView roundView;
        [SerializeField] private MenuGameView menuView;
        public override void InstallBindings()
        {
            Container.Bind<MainGameView>()
                .FromComponentInNewPrefab(mainView)
                .WithGameObjectName("GameUI")
                .AsSingle()
                .NonLazy();
            
            Container.Bind<RoundGameView>()
                .FromComponentInNewPrefab(roundView)
                .WithGameObjectName("RoundView").UnderTransformGroup("GameUI")
                .AsSingle()
                .NonLazy();
            Container.Bind<MenuGameView>()
                .FromComponentInNewPrefab(menuView)
                .WithGameObjectName("MenuView").UnderTransformGroup("GameUI")
                .AsSingle()
                .NonLazy();
            Container.DeclareSignal<ButtonClickedSignal>().OptionalSubscriber();
        }
    }
}