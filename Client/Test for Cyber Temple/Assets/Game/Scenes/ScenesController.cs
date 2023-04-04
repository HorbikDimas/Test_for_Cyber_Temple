using System;
using Cysharp.Threading.Tasks;
using Game.Scenes.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scenes
{
    public class ScenesController : SceneManagerAPI, IInitializable, IDisposable
    {
        private const int LoadingSceneIndex = (int)GameScene.Loading;
        private const int MainSceneIndex = (int)GameScene.Main;
        private const int StartSceneIndex = (int)GameScene.Start;

        private readonly SignalBus _signalBus;

        public ScenesController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        void IInitializable.Initialize()
        {
            overrideAPI = this;
        }
        void IDisposable.Dispose()
        {
            overrideAPI = null;
        }

        public async UniTask RestartGameAsync()
        {
            await LoadLoadingAsync(true);

            await SceneManager.LoadSceneAsync(StartSceneIndex);
            //TODO: Logger "Restart game"
        }

        public async UniTask LoadMenuAsync(bool showLoading)
        {
            await LoadLoadingAsync(showLoading);

            await SceneManager.LoadSceneAsync(MainSceneIndex);
            //TODO: Logger "Main scene is loaded."
        }

        private async UniTask LoadLoadingAsync(bool showLoading)
        {
            //if (showLoading) _guiManager.Show<LoadingView>();

            try
            {
                await SceneManager.LoadSceneAsync(LoadingSceneIndex);
            }
            finally
            {
                await Resources.UnloadUnusedAssets();
                GC.Collect();
            }
        }
        protected override AsyncOperation LoadSceneAsyncByNameOrIndex(string sceneName, int sceneBuildIndex,
            LoadSceneParameters parameters, bool mustCompleteNextFrame)
        {
            _signalBus.Fire(new SceneLoadingSignal((GameScene)sceneBuildIndex));

            return base.LoadSceneAsyncByNameOrIndex(sceneName, sceneBuildIndex, parameters, mustCompleteNextFrame);
        }
    }
}