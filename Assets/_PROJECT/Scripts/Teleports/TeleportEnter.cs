using System.Collections.Generic;
using PacMan.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace PacMan.Teleports
{
    public class TeleportEnter : MonoBehaviour
    {
        [Inject] private IPlayer player;
        [Inject] private List<TeleportExit> exitPoints;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(Keys.Tag.PLAYER))
            {
                player.ChangePosition(RandExitPosition());
            }
        }
        
        private Vector3 RandExitPosition()
        {
            return exitPoints[Random.Range(0, exitPoints.Count)].transform.position;
        }
    }
}