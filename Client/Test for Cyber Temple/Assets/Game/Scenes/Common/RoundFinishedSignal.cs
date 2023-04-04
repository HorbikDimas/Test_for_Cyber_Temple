using UnityEngine;

namespace Game.Scenes.Common
{
    public class RoundFinishedSignal 
    {
        public RoundFinishedSignal(int roundResults)
        {
            RoundResults = roundResults;
        }

        public int RoundResults { get; }
    }
}
