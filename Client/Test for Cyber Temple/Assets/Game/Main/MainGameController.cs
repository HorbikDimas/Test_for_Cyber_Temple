using System;
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
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<ButtonClickedSignal>(OnButtonClicked);
        }

        private void OnButtonClicked(ButtonClickedSignal signal)
        {
            switch (signal.View)
            {
                case ViewType.Round:
                    _signalBus.Fire<StartRoundSignal>();
                    break;
                case ViewType.Menu:
                    _signalBus.Fire<RoundFinishedSignal>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }
}