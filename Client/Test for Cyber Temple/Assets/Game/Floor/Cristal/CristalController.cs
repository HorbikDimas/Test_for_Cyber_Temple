using System;
using System.Collections.Generic;
using Game.GUI.Game;
using Game.Scenes.Common;
using Game.Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Floor.Cristal
{
    public class CristalController : MonoBehaviour
    {
        private readonly List<GameObject> _cristalBodies = new();
        private CristalBody _cristalBody;
        private DiContainer _diContainer;
        private FlorController _florController;
        private int _index;
        private bool _list;
        private GameSettings _settings;
        private SignalBus _signalBus;

        private void Start()
        {
            foreach (var segment in _florController.segmentFlor)
                _cristalBodies.Add(_diContainer.InstantiatePrefab(_cristalBody, segment));
            foreach (var cristal in _cristalBodies) cristal.SetActive(false);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<StartRoundSignal>(OnStartRound);
            _signalBus.Subscribe<SegmentMovingSignal>(OnSegmentMoving);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<StartRoundSignal>(OnStartRound);
            _signalBus.Unsubscribe<SegmentMovingSignal>(OnSegmentMoving);
        }

        private void OnSegmentMoving(SegmentMovingSignal signal)
        {
            for (var i = 0; i < _cristalBodies.Count; i++)
                if (signal.Index == i)
                    _cristalBodies[i].SetActive(false);
            switch (_settings.CristalSpawnType)
            {
                case CristalSpawnType.Random:
                    SpawnRandomCristal(signal.Index);
                    break;
                case CristalSpawnType.List:
                    SpawnListCristal(signal.Index);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnStartRound()
        {
            _list = true;
            switch (_settings.CristalSpawnType)
            {
                case CristalSpawnType.Random:
                    SpawnRandomCristal(Random.Range(0, _cristalBodies.Count));
                    break;
                case CristalSpawnType.List:
                   
                    SpawnListCristal(0);
                    _list = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SpawnRandomCristal(int index)
        {
            if (_index == index && _list)
            {
                _index = Random.Range(0, _cristalBodies.Count);
                _cristalBodies[index].SetActive(true);
            }
            if (index >= _cristalBodies.Count-1)
                _list = true;
        }

        private void SpawnListCristal(int index)
        {
            if (_index == index && _list)
            {
                _index++;
                _cristalBodies[index].SetActive(true);
                _list = false;
            }

            if (index >= _cristalBodies.Count-1)
                _list = true;
            if (_index >= _cristalBodies.Count)
                _index = 0;

        }

        [Inject]
        public void Constructor(SignalBus signalBus, GameSettings settings, DiContainer diContainer,
            CristalBody cristalBody,
            FlorController florController)
        {
            _signalBus = signalBus;
            _settings = settings;
            _diContainer = diContainer;
            _cristalBody = cristalBody;
            _florController = florController;
        }
    }
}