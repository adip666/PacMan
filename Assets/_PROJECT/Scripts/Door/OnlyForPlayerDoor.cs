using UnityEngine;

namespace PacMan.Keys.Door
{
    public class OnlyForPlayerDoor : BaseDoor
    {
        protected override bool CanReact(Collider other)
        {
            return other.transform.CompareTag(Tag.PLAYER);
        }
    }
}