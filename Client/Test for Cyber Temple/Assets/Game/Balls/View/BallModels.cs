using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Balls.View
{
    [Serializable]
    public class BallModels
    {
        [SerializeField] private BallBody defaultBall;

        [SerializeField] private List<BallBody> list;

        public BallBody Get(BallModelType modelType)
        {
            return list.FirstOrDefault(h => h.modelType == modelType) ?? defaultBall;
        }
    }
}