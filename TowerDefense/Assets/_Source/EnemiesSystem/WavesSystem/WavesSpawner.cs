using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using EnemiesSystem.EnemyMovement;
using UnityEditor;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    public class WavesSpawner : MonoBehaviour
    {
        [SerializeField] private Waves[] waves;
        [SerializeField] private UnitsPool enemyPool;
        [SerializeField] private float delayBetweenWaves;
        private List<GameObject> _activeEnemies;
        private int _enemiesCount;
        public static int EnemiesInWave { get; set; }
        private int _currentWaveIndex;
        
        

        public void Construct()
        {
            _activeEnemies = new List<GameObject>();
            _enemiesCount = waves[_currentWaveIndex].EnemySettings.Length;
            Init();
            StartCoroutine(EnemiesSpawn());
        }

       
        private void Init()
        {
            enemyPool.InitPool();
            
        }

        private void Update()
        {


            StartCoroutine(LaunchNextWave());

        }

        private IEnumerator LaunchNextWave()
        {
            if (_activeEnemies!= null && _activeEnemies.Count(enemy => enemy.activeSelf == false) == EnemiesInWave
                                     && _activeEnemies.Count(enemy => enemy.activeSelf == false) != 0)
            {
                foreach (var enemy in _activeEnemies)
                {
                    enemyPool.ReturnToPool(enemy);
                    
                }
                if (_currentWaveIndex < waves.Length )
                {
                    _activeEnemies = null;
                    _enemiesCount = waves[_currentWaveIndex].EnemySettings.Length;
                    Debug.Log("next");
                    yield return new WaitForSeconds(delayBetweenWaves);
                    EnemiesInWave = 0;
                    StartCoroutine(EnemiesSpawn());
                    
                }
            }
            
        }
        private IEnumerator EnemiesSpawn()
        {
            
            _activeEnemies = new List<GameObject>();
                for (int i = 0; i < _enemiesCount; i++)
                {
                    yield return new WaitForSeconds(waves[_currentWaveIndex]
                        .EnemySettings[i]
                        .SpawnDelay);
                    enemyPool.TryGetFromPool(out GameObject enemyInstance);
                    var enemy = enemyPool.Enemies[enemyInstance];
                    enemy.Init(waves[_currentWaveIndex].EnemySettings[i].EnemyData);
                    enemyInstance.transform.position = waves[_currentWaveIndex].EnemySettings[i].SpawnPoint.transform.position;
                    enemyInstance.TryGetComponent(out Movement movement);
                    movement.Move(enemy);
                    EnemiesInWave++;
                    
                    _activeEnemies.Add(enemyInstance);
                    Debug.Log(EnemiesInWave);
                }

                _currentWaveIndex++;
            
        }
    }
}
