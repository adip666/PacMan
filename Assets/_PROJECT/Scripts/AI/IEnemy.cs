using Zenject;

namespace PacMan.AI
{
    public interface IEnemy : IFixedTickable
    {
        float Speed { set; }
    }
}