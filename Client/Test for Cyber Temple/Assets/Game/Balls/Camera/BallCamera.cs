using UnityEngine;
using Zenject;

namespace Game.Balls.Camera
{
    public class BallCamera : MonoBehaviour
    {
        private Transform _transform;

        private void LateUpdate()
        {
            transform.position =_transform.position;
        }

        [Inject]
        public void Construct(Ball ball)
        {
            _transform = ball.transform;
        }
    }
}