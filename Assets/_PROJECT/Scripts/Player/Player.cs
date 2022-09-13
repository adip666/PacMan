using Signals;
using SignalsSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace PacMan.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerInput input;
        
        private  ISignalSystem signalSystem;
        private int currentLife = 3;
        private void Start()
        {
            signalSystem.FireSignal(new PlayerLifeChangedSignal(currentLife));
        }

        [Inject]
        public void Inject(ISignalSystem signalSystem)
        {
            this.signalSystem = signalSystem;
        }
        
        public void AddDamage()
        {
            currentLife--;
            signalSystem.FireSignal(new PlayerLifeChangedSignal(currentLife));
            if (currentLife == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            input.enabled = false;
            signalSystem.FireSignal<PlayerDeadSignal>();
        }
    }
}