using PacMan.Keys;
using UnityEngine;

namespace PacMan.Door
{
    public class BaseDoor : MonoBehaviour
    {
        private Vector3 openedPos = new Vector3(0, -2.87f, 0);
        private Vector3 closedPos = new Vector3(0, 1.07f, 0);
        [SerializeField] private Transform door;

        private void OnTriggerEnter(Collider other)
        {
            if (CanReact(other))
            {
                Open();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (CanReact(other))
            {
                CancelInvoke(nameof(Close));
                Invoke(nameof(Close), .5f);
            }
        }

        protected virtual bool CanReact(Collider other)
        {
            return other.transform.CompareTag(Tag.PLAYER) ||
                   other.transform.CompareTag(Tag.ENEMY);
        }


        private void Open()
        {
            door.transform.localPosition = openedPos;
        }

        private void Close()
        {
            door.transform.localPosition = closedPos;
        }
    }
}