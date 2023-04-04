using System;
using Game.GUI.Game.Menu;
using Game.GUI.Game.Round;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.GUI.Game.Main
{
    public class MainGameView : MonoBehaviour
    {
        private SignalBus _signalBus;
        private MenuGameView _menuGameView;
        private RoundGameView _roundGameView;

        private void Start()
        {
            OnSetActiveView(ViewType.Menu);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<ButtonClickedSignal>(OnButtonClicked);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<ButtonClickedSignal>(OnButtonClicked);
        }

        [Inject]
        public void Construct(SignalBus signalBus, MenuGameView menuGameView, RoundGameView roundGameView)
        {
            _signalBus = signalBus;
            _menuGameView = menuGameView;
            _roundGameView = roundGameView;
        }
        private void OnButtonClicked(ButtonClickedSignal signal)
        {
            OnSetActiveView(signal.View);
        }

        private void OnSetActiveView(ViewType type)
        {
            _menuGameView.gameObject.SetActive(type == ViewType.Menu);
            _roundGameView.gameObject.SetActive(type == ViewType.Round);
        }
        


    }
}
