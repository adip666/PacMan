using Signals;
using SignalsSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace PacMan.UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lifeValue;
        private ISignalSystem signalSystem;

        [Inject]
        private void Inject(ISignalSystem signalSystem)
        {
            this.signalSystem = signalSystem;
        }

        private void Awake()
        {
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<PlayerLifeChangedSignal>(OnLifeChanged);
        }

        private void OnLifeChanged(PlayerLifeChangedSignal signal)
        {
            lifeValue.text = signal.CurrentPlayerLife.ToString();
        }

        private void OnDestroy()
        {
            UnSubscribeSignals();
        }

        private void UnSubscribeSignals()
        {
            signalSystem.UnsubscribeSignal<PlayerLifeChangedSignal>(OnLifeChanged);
        }
    }
}