using System.Collections;
using System.Collections.Generic;
using PacMan.AI;
using PacMan.Keys;
using PacMan.SceneManagement;
using PacMan.Seeds;
using PacMan.UI;
using Signals;
using SignalsSystem;
using UnityEngine;
using Zenject;


namespace PacMan.Core
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private GameSettings gameSettings;

        private readonly List<IEnemy> enemies = new List<IEnemy>();
        private EnemyFactory<Enemy> spawner;
        private ISignalSystem signalSystem;
        private IEndGameView endGameView;
        private ISceneManager sceneManager;
        private List<Seed> seeds = new List<Seed>();
        private int currentLevel = -1;
        private List<EnemySpawnPoint> enemySpawns = new List<EnemySpawnPoint>();

       

        public int CurrentLevel
        {
            get
            {
                if (currentLevel == -1)
                {
                    currentLevel = LoadLevel();
                }

                return currentLevel;
            }
        }

        [Inject]
        public void Inject(EnemyFactory<Enemy> spawner,
            ISignalSystem signalSystem,
            IEndGameView endGameView,
            ISceneManager sceneManager,
            List<EnemySpawnPoint> enemySpawns)
        {
            this.spawner = spawner;
            this.signalSystem = signalSystem;
            this.endGameView = endGameView;
            this.sceneManager = sceneManager;
            this.enemySpawns = enemySpawns;
        }
        
        public void RegisterSeed(Seed seed)
        {
            seeds.Add(seed);
        }

        public void UnRegisterSeed(Seed seed)
        {
            seeds.Remove(seed);
            CheckGameCondition();
        }
        public void RestartGame()
        {
            PlayerPrefs.SetInt(Key.LIFE_PREFS_NAME, Values.PLAYER_LIFE);
            PlayerPrefs.SetInt(Key.LEVEL_PREFS_NAME, 1);
        }

        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<PlayerDeadSignal>(OnPlayerDead);
        }

        private void Start()
        {
            Debug.Log("Start lvl: " + CurrentLevel);
            PrepareEnemySpawns();
            if (!CursorIsLocked())
            {
                LockCursor();
            }

            SubscribeSignals();
            StartCoroutine(SpawnEnemy());
        }

        private void PrepareEnemySpawns()
        {
            Levels spawnsToRemove = CurrentLevel == 1 ? Levels.Level_2 : Levels.Level_1;
            enemySpawns.RemoveAll(s => s.spawnAtLevel == spawnsToRemove);
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
            Levels level = CurrentLevel == 1 ? Levels.Level_1 : Levels.Level_2;

            int enemyCount = gameSettings.GetEnemyValue(level);
            for (int i = 0; i < enemyCount; i++)
            {
                Enemy enemy = spawner.Create();
                enemy.transform.position = DrawStartPoint();
                enemy.Speed = gameSettings.GetEnemySpeed(level);
                enemies.Add(enemy);
                yield return new WaitForSeconds(2);
            }
        }

        private Vector3 DrawStartPoint()
        {
            return enemySpawns[Random.Range(0, enemySpawns.Count)].transform.position;
        }

        private void FixedUpdate()
        {
            if (!IsGameWin())
            {
                foreach (var enemy in enemies)
                {
                    enemy.FixedTick();
                }
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

        

        private void CheckGameCondition()
        {
            if (IsGameWin())
            {
                if (CurrentLevel == 1)
                {
                    StartNextLevel();
                }
                else
                {
                    signalSystem.FireSignal<EndGameSignal>();
                    UnLockCursor();
                    endGameView.ShowWinPanel();
                }
            }
        }

        private void StartNextLevel()
        {
            PlayerPrefs.SetInt(Key.LEVEL_PREFS_NAME, 2);
            sceneManager.RestartGame();
        }

        private int LoadLevel()
        {
            if (!PlayerPrefs.HasKey(Key.LEVEL_PREFS_NAME))
            {
                return 1;
            }

            return PlayerPrefs.GetInt(Key.LEVEL_PREFS_NAME);
        }

        private bool IsGameWin()
        {
            return seeds.Count == 0;
        }
    }
}