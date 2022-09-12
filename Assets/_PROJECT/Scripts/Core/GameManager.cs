using System;
using System.Collections;
using System.Collections.Generic;
using PacMan.AI;
using PacMan.Installers;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private EnemyFactory<Enemy> spawner;
    private const int enemyCount = 5;
    private List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(spawner.Create());
            yield return new  WaitForSeconds(2);
        }
    }

    private void FixedUpdate()
    {
        foreach (var enemy in enemies)
        {
            enemy.FixedTick();
        }
    }
}