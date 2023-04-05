using UnityEngine;
using Zenject;

namespace Game.Floor.Cristal
{
    public class CristalBody : MonoBehaviour
    {
        private SignalBus _signalBus;
        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            _signalBus.Fire(new CristalColisionSignal());
        }

        [Inject]
        public void Constructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

    }
}
