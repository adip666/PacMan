using System;
using System.Collections.Generic;
using PacMan.Keys;
using UnityEngine;

namespace PacMan.Core
{
    [Serializable]
    public struct LevelData
    {
        public Levels level;
        public int enemyCount;
        public float enemySpeed;
    }

    [CreateAssetMenu(menuName = "Settings/New Game Settings Settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private List<LevelData> data = new List<LevelData>();


        public int GetEnemyValue(Levels level)
        {
            return data.Find(s => s.level == level).enemyCount;
        }

        public float GetEnemySpeed(Levels level)
        {
            return data.Find(s => s.level == level).enemySpeed;
        }
    }
}