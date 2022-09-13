using SignalsSystem;

namespace Signals
{
    public class PlayerLifeChangedSignal : ICustomSignal
    {
        public int CurrentPlayerLife { get; }

        public PlayerLifeChangedSignal(int currentPlayerLife)
        {
            this.CurrentPlayerLife = currentPlayerLife;
        }
    }
}