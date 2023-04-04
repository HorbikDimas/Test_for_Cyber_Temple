using System;
using Game.Balls.Input;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Balls.Moving
{
    public class BallMoveEngine : MonoBehaviour
    {
        [SerializeField] private BallInputHandler ballInputHandler;
        private Vector3 _direction;
        private GameSettings _settings;
        private float _speed;

        private void Update()
        {
            if (ballInputHandler.TapDown) _direction = _direction == Vector3.forward ? Vector3.right : Vector3.forward;
        }

        private void FixedUpdate()
        {
            transform.Translate(_direction * _speed);
        }

        public void Init(float speed)
        {
            _speed = speed;
        }
    }
}