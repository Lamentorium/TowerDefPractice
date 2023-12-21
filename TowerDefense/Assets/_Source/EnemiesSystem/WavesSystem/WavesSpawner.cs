using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using EnemiesSystem.Data;
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
        [SerializeField] private bool bossInWave;
        [SerializeField] private GameObject bossPrefab;
        [SerializeField] private GameObject winScreen;
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

            if (_activeEnemies != null && _activeEnemies.Count(enemy => enemy.activeSelf == false) == EnemiesInWave
                                       && _activeEnemies.Count(enemy => enemy.activeSelf == false) != 0)
            {
                StartCoroutine(LaunchNextWave());
            }

           

        }

        private IEnumerator LaunchNextWave()
        {

            foreach (var enemy in _activeEnemies)
            {
                enemyPool.ReturnToPool(enemy);

            }
            if (_currentWaveIndex == waves.Length - 1 && bossInWave)
            {
                enemyPool.InitPool(bossPrefab);
                
            }
            if (_currentWaveIndex < waves.Length)
            {
                _activeEnemies = null;
                _enemiesCount = waves[_currentWaveIndex].EnemySettings.Length;
                //Debug.Log("next");
                yield return new WaitForSeconds(delayBetweenWaves);
                EnemiesInWave = 0;
               
                StartCoroutine(EnemiesSpawn());

            }
            else
            {
                winScreen.SetActive(true);
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
                //var enemyMove = new Movement(waves[_currentWaveIndex].EnemySettings[i].DestinationPoints);
                //enemyMove.Move(enemy);
                EnemiesInWave++;
                if (enemyInstance.TryGetComponent(out Movement enemyMove))
                {
                    enemyMove.enabled = true;
                    enemyMove.Init(waves[_currentWaveIndex].EnemySettings[i].DestinationPoints, waves[_currentWaveIndex].EnemySettings[i].SpawnPoint.transform);
                    _activeEnemies.Add(enemyInstance);

                }
                // Debug.Log(EnemiesInWave);
            }

            _currentWaveIndex++;

        }
    }
}
