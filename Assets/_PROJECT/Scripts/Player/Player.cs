using Signals;
using SignalsSystem;
using UnityEngine;
using Zenject;

namespace PacMan.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        private  ISignalSystem signalSystem;
        private int life = 3;
       
        [Inject]
        public void Inject(ISignalSystem signalSystem)
        {
            this.signalSystem = signalSystem;
        }
        
        public void AddDamage()
        {
            life--;
            signalSystem.FireSignal(new PlayerLifeChangedSignal(life));
            if (life < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            signalSystem.FireSignal<PlayerDeadSignal>();
        }
    }
}