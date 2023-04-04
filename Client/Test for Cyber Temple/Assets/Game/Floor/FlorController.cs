using System;
using Game.GUI.Game;
using Game.Scenes.Common;
using Game.Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Floor
{
    public class FlorController : MonoBehaviour
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform[] segmentFlor;
        private int _indexSegment;
        private Vector3 _positionSegment;
        private bool _roundActive;
        private float _scaleSegment;
        private GameSettings _settings;
        private SignalBus _signalBus;
        private float _timer;
        private float _timerSpawn;

        private void Update()
        {
            if (!_roundActive) return;
            _timer += Time.deltaTime;
            if (_timer < _timerSpawn) return;
            UpdateSegment();
            _timer = 0;
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
            _scaleSegment = _settings.ComplexityType switch
            {
                ComplexityType.Easy => 3f,
                ComplexityType.Normal => 2f,
                ComplexityType.Hard => 1f,
                _ => _scaleSegment
            };
            startPosition.localPosition = _settings.ComplexityType switch
            {
                ComplexityType.Easy => Vector3.forward * 3f,
                ComplexityType.Normal => Vector3.forward * 2.5f,
                ComplexityType.Hard => Vector3.forward * 2f,
                _ => throw new ArgumentOutOfRangeException()
            };

            foreach (var segment in segmentFlor) segment.localScale = new Vector3(_scaleSegment, 0.5f, _scaleSegment);
            foreach (var segment in segmentFlor)
            {
                segment.localPosition = _positionSegment;
                if (Random.value < 0.5f)
                    _positionSegment += Vector3.forward * _scaleSegment;
                else
                    _positionSegment += Vector3.right * _scaleSegment;
            }

            _roundActive = true;
            _timerSpawn = _scaleSegment / _settings.GameSpeed;
            _timer = -_timerSpawn;
        }

        private void OnRoundFinish()
        {
            _roundActive = false;
            _positionSegment = Vector3.zero;
            _indexSegment = 0;
        }

        private void UpdateSegment()
        {
            segmentFlor[_indexSegment].localPosition = _positionSegment;
            if (Random.value < 0.5f)
                _positionSegment += Vector3.forward * _scaleSegment;
            else
                _positionSegment += Vector3.right * _scaleSegment;
            if (_indexSegment < segmentFlor.Length - 1)
                _indexSegment++;
            else
                _indexSegment = 0;
        }

        [Inject]
        public void Construct(SignalBus signalBus, GameSettings settings)
        {
            _signalBus = signalBus;
            _settings = settings;
        }
    }
}