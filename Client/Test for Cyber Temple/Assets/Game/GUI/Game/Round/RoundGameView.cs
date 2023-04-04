using System;
using Game.Scenes.Common;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.GUI.Game.Round
{
    public class RoundGameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cristalText;
        private SignalBus _signalBus;
        private void OnEnable()
        {
            cristalText.text = 0.ToString();
            _signalBus.Subscribe<RoundFinishedSignal>(OnRoundFinish);
        }
        private void OnRoundFinish()
        {
            _signalBus.Fire(new ButtonClickedSignal(ViewType.Menu));
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RoundFinishedSignal>(OnRoundFinish);
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }

}