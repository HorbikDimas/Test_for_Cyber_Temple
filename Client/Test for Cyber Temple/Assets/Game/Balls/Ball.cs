using System;
using Game.Balls.Input;
using Game.Balls.Moving;
using Game.Balls.View;
using Game.Scenes.Common;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Balls
{
    [RequireComponent(typeof(BallInputHandler))]
    [RequireComponent(typeof(BallMoveEngine))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallMoveEngine _move;

        private readonly BallModelType _modelType = BallModelType.Default;
        private BallBody _body;
        private BallModels _models;
        private GameSettings _settings;
        private SignalBus _signalBus;

        private void Start()
        {
            _body = Instantiate(_models.Get(_modelType), transform);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<StartRoundSignal>(OnStartRound);
            _signalBus.Subscribe<RoundFinishedSignal>(OnRoundFinish);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<StartRoundSignal>(OnStartRound);
            _signalBus.Unsubscribe<RoundFinishedSignal>(OnRoundFinish);
        }

        private void OnStartRound()
        {
            _move.enabled = true;
            _move.Init(_settings.GameSpeed, _signalBus);
        }

        private void OnRoundFinish()
        {
            _move.enabled = false;
            transform.position = Vector3.zero;
        }


        [Inject]
        public void Construct(BallModels models, GameSettings settings, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _settings = settings;
            _models = models;
        }
    }
}