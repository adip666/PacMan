using PacMan.AI;
using UnityEngine;
using Zenject;

namespace PacMan.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Enemy enemy;
        public override void InstallBindings()
        {
            Container.BindFactory<Enemy, EnemyFactory<Enemy>>().FromComponentInNewPrefab(enemy);
        }
    }
}

