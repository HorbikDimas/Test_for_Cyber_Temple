using Game.Balls.Input;
using Game.Balls.Moving;
using Game.Balls.View;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Balls
{
    [RequireComponent(typeof(BallInputHandler))]
    [RequireComponent(typeof(BallMoveEngine))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallInputHandler _input;
        [SerializeField] private BallMoveEngine _move;
        private BallModels _models;
        private BallBody _body;
        
        private BallModelType _modelType = BallModelType.Default;

        private void Start()
        {
            _body = Instantiate(_models.Get(_modelType),transform) ;
        }

        [Inject]
        public void Construct(BallModels models, GameSettings settings)
        {
            _models = models;
            _move.Init(settings);
        }
    }
}