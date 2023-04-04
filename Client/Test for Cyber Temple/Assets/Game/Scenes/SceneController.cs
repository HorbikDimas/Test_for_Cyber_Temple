using Game.Scenes.Common;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scenes
{
    public class SceneController
    {
        private const int LoadingSceneIndex = (int)GameScene.Loading;
        private const int MainSceneIndex = (int)GameScene.Main;
        private const int StartSceneIndex = (int)GameScene.Start;

        private readonly SignalBus _signalBus;

        public SceneController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public async UniTask RestartGameAsync()
        {
            await LoadLoadingAsync(true);

            await SceneManager.LoadSceneAsync(StartSceneIndex);
        }
    }
}