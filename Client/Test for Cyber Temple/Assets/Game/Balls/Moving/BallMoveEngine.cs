using Game.Balls.Input;
using Game.Scenes.Common;
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
        private SignalBus _signalBus;
        private float _speed;

        private void Update()
        {
            if (ballInputHandler.TapDown) _direction = _direction == Vector3.forward ? Vector3.right : Vector3.forward;
        }

        private void FixedUpdate()
        {
            transform.Translate(_direction * (Time.deltaTime * _speed)  );
            if (transform.position.y < 0)
            {
                _signalBus.Fire(new RoundFinishedSignal());
            }
        }

        private void OnEnable()
        {
            _direction = Vector3.forward;
        }

        public void Init(float speed,SignalBus signalBus)
        {
            _speed = speed;
            _signalBus = signalBus;
        }
    }
}