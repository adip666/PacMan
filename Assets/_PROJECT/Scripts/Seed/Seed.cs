
using PacMan.Core;
using UnityEngine;
using Zenject;

namespace PacMan.Seeds
{
    public class Seed : MonoBehaviour
    {
        [Inject] IGameManager gameManager;
        private void Start()
        {
            gameManager.RegisterSeed(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(Keys.Tag.PLAYER))
            {
                Collect();
            }
        }

        private void Collect()
        {
            gameManager.UnRegisterSeed(this);
            Destroy(gameObject);
        }
    }
}