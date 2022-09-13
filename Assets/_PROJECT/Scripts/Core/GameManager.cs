using System.Collections;
using System.Collections.Generic;
using PacMan.AI;
using PacMan.Installers;
using Signals;
using SignalsSystem;
using UnityEngine;
using Zenject;


namespace PacMan.Core
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        private  EnemyFactory<Enemy> spawner;
        private  ISignalSystem signalSystem;
        private readonly List<IEnemy> enemies = new List<IEnemy>();
        
        private const int enemyCount = 5;

        [Inject]
        public void Inject(EnemyFactory<Enemy> spawner, ISignalSystem signalSystem)
        {
            this.spawner = spawner;
            this.signalSystem = signalSystem;
        }

        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<PlayerDeadSignal>(OnPlayerDead);
        }

        private void Start()
        {
            SubscribeSignals();
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies.Add(spawner.Create());
                yield return new WaitForSeconds(2);
            }
        }

        private void FixedUpdate()
        {
            foreach (var enemy in enemies)
            {
                enemy.FixedTick();
            }
        }

        private void OnPlayerDead()
        {
            UnSubscribeSignals();
            Time.timeScale = 0;
        }
        
        private void UnSubscribeSignals()
        {
            signalSystem.UnsubscribeSignal<PlayerDeadSignal>(OnPlayerDead);
        }
    }
}