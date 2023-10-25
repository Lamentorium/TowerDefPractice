using System;
using System.Collections.Generic;
using EnemiesSystem.Data;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private EnemyDataSO enemyData;
        public EnemyDataSO EnemyData => enemyData;
        [SerializeField] private GameObject spawnPoint;
        public GameObject SpawnPoint => spawnPoint;
        [SerializeField] private float spawnDelay;
        public float SpawnDelay => spawnDelay;
        [SerializeField] private int health;
        

        [SerializeField] private int armor;
        

    }
}
