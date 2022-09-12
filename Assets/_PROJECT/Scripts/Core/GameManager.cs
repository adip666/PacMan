using System.Collections;
using System.Collections.Generic;
using PacMan.AI;
using PacMan.Installers;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private EnemyFactory<Enemy> spawner;
    void Start()
    {
        spawner.Spawn();
    }
    
}
