using System.Collections;
using System.Collections.Generic;
using PacMan.AI;
using PacMan.Installers;
using PacMan.UI;
using Signals;
using SignalsSystem;
using UnityEngine;
using Zenject;


namespace PacMan.Core
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        private readonly List<IEnemy> enemies = new List<IEnemy>();
        private  EnemyFactory<Enemy> spawner;
        private  ISignalSystem signalSystem;
        private IEndGameView endGameView;
        
        private const int enemyCount = 5;

        [Inject]
        public void Inject(EnemyFactory<Enemy> spawner, ISignalSystem signalSystem, IEndGameView endGameView)
        {
            this.spawner = spawner;
            this.signalSystem = signalSystem;
            this.endGameView = endGameView;
        }

        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<PlayerDeadSignal>(OnPlayerDead);
        }

        private void Start()
        {
            if (!CursorIsLocked())
            {
                LockCursor();
            }
            
            SubscribeSignals();
            StartCoroutine(SpawnEnemy());
        }

        private bool CursorIsLocked()
        {
            return Cursor.lockState == CursorLockMode.Locked;
        }

        private void LockCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void UnLockCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
            UnLockCursor();
            endGameView.ShowLosePanel();
        }
        
        private void UnSubscribeSignals()
        {
            signalSystem.UnsubscribeSignal<PlayerDeadSignal>(OnPlayerDead);
        }
    }
}