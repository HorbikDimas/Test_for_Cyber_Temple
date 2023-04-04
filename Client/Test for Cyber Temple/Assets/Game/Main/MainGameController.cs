using Game.GUI;
using Game.GUI.Game;
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
            _signalBus.Subscribe<ButtonClickedSignal>(OnButtonClicked);
            _signalBus.Subscribe<RoundFinishedSignal>(OnRoundFinish);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<ButtonClickedSignal>(OnButtonClicked);
            _signalBus.Unsubscribe<RoundFinishedSignal>(OnRoundFinish);
        }

        private void OnRoundFinish()
        {
            _signalBus.Fire(new ButtonClickedSignal(ViewType.Menu));
        }

        private void OnButtonClicked(ButtonClickedSignal signal)
        {
            if (signal.View == ViewType.Round)
                _signalBus.Fire(new StartRoundSignal());
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }
}