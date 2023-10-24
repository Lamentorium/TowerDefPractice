using System;
using EnemiesSystem.Data;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private GameObject enemyPrefab;
        public GameObject EnemyPrefab => enemyPrefab;
        [SerializeField] private GameObject spawnPoint;
        public GameObject SpawnPoint => spawnPoint;
        [SerializeField] private float spawnDelay;
        public float SpawnDelay => spawnDelay;
        [SerializeField] private int health;
        

        [SerializeField] private int armor;
        

        private Enemy _enemy;

        public void Construct(Enemy enemy)
        { 
            _enemy = enemy;
            health = _enemy.Health;
            armor = _enemy.Armor;
        }

    }
}
