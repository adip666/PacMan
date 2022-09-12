using UnityEngine;
using Zenject;

namespace PacMan.Installers
{
    public class EnemyFactory<T> : PlaceholderFactory<T>
    {
        public void Spawn()
        {
            Create();
        }
        
    }
}