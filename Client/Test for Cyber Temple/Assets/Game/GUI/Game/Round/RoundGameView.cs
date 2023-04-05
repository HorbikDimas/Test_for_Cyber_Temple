using Game.Floor.Cristal;
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
        private int _cristal;

        private void OnEnable()
        {
            cristalText.text = 0.ToString();
            _signalBus.Subscribe<RoundFinishedSignal>(OnRoundFinish);
            _signalBus.Subscribe<CristalColisionSignal>(OnCristalCollision);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RoundFinishedSignal>(OnRoundFinish);
            _signalBus.Unsubscribe<CristalColisionSignal>(OnCristalCollision);
        }

        private void OnCristalCollision()
        {
            _cristal++;
            cristalText.text = _cristal.ToString();
        }

        private void OnRoundFinish()
        {
            _signalBus.Fire(new ButtonClickedSignal(ViewType.Menu));
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }
}