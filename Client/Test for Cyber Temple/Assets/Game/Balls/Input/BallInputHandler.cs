using System;
using UnityEngine;

namespace Game.Balls.Input
{
    public class BallInputHandler : MonoBehaviour
    {
        public bool TapDown { get; private set; }
        private void Update()
        {
            TapDown = UnityEngine.Input.GetMouseButtonDown(0);
        }
    }
}
