using PacMan.Keys;
using Signals;
using SignalsSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Key = PacMan.Keys.Key;

namespace PacMan.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private CharacterController controller;
        private ISignalSystem signalSystem;
        private int currentLife = -1;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.position;
            currentLife = LoadLife();
            signalSystem.FireSignal(new PlayerLifeChangedSignal(currentLife));
            signalSystem.SubscribeSignal<EndGameSignal>(OnGameEnd);
        }

        [Inject]
        public void Inject(ISignalSystem signalSystem)
        {
            this.signalSystem = signalSystem;
        }

        private int LoadLife()
        {
            return PlayerPrefs.GetInt(Key.LIFE_PREFS_NAME);
        }

        public void AddDamage()
        {
            currentLife--;
            signalSystem.FireSignal(new PlayerLifeChangedSignal(currentLife));
            PlayerPrefs.SetInt(Key.LIFE_PREFS_NAME, currentLife);

            if (currentLife == 0)
            {
                Die();
            }
            else
            {
                ResetPosition();
            }
        }

        public void ChangePosition(Vector3 position)
        {
            controller.enabled = false;
            transform.position = position;
            controller.enabled = true;
        }

        [ContextMenu("ResetPos")]
        private void ResetPosition()
        {
            controller.enabled = false;
            transform.position = startPosition;
            controller.enabled = true;
        }

        private void Die()
        {
            input.enabled = false;
            signalSystem.FireSignal<PlayerDeadSignal>();
        }

        private void OnGameEnd()
        {
            input.enabled = false;
        }

        private void OnDestroy()
        {
            signalSystem.UnsubscribeSignal<EndGameSignal>(OnGameEnd);
        }
    }
}