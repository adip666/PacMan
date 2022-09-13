using UnityEngine;

namespace PacMan.Player
{
    public interface IPlayer
    {
        void AddDamage();

        void ChangePosition(Vector3 position);
    }
}