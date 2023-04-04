using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Game.Scenes.Start
{
    public class StartSceneController : MonoBehaviour
    {
        private ScenesController _scenesController;
        private SignalBus _signalBus;

        private async void Start()
        {
            await LoadGameAsync();
        }

        [Inject]
        public void Construct(SignalBus signalBus, ScenesController scenesController)
        {
            _signalBus = signalBus;
            _scenesController = scenesController;
        }

        private async Task LoadGameAsync()
        {
            await _scenesController.LoadMenuAsync(false);
        }
    }
}