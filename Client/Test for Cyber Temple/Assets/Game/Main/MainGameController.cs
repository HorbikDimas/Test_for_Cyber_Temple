using Game.Scenes.Common;
using UnityEngine;
using Zenject;

namespace Game.Main
{
    public class MainGameController : MonoBehaviour
    {
        private SignalBus _signalBus;

        private void OnEnable()
        {
            _signalBus.Subscribe<RoundFinishedSignal>(OnRoundFinished);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RoundFinishedSignal>(OnRoundFinished);
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnRoundFinished(RoundFinishedSignal signal)
        {
        }
    }
}