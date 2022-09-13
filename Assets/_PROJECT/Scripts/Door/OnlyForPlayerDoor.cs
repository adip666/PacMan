using PacMan.Keys;
using UnityEngine;

namespace PacMan.Door
{
    public class OnlyForPlayerDoor : BaseDoor
    {
        protected override bool CanReact(Collider other)
        {
            return other.transform.CompareTag(Tag.PLAYER);
        }
    }
}