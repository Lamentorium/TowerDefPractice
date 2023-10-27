using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    public class WavesSpawner : MonoBehaviour
    {
        [SerializeField] private Waves[] waves;
        [SerializeField] private UnitsPool enemyPool;
        [SerializeField] private float delayBetweenWaves;
        private List<GameObject> activeEnemies;
        private int _enemiesCount;

        public static int EnemiesInWave { get; set; }
        private int _currentWaveIndex;


        private void Start()
        {
            activeEnemies = new List<GameObject>();
            _enemiesCount = waves[_currentWaveIndex].EnemySettings.Length;
            enemyPool.Construct(waves);
            Init();
            LaunchNextWave();
            
        }

        /*private void OnEnable()
        {
            TestWaveSystem.Action += ChangeValue;
        }

        private void OnDisable()
        {
            TestWaveSystem.Action -= ChangeValue;
        }*/

        private void Init()
        {
            enemyPool.InitPool();
        }

        private void Update()
        {
            

            if (activeEnemies.Count(enemy => enemy.activeSelf == false) == EnemiesInWave
                && activeEnemies.Count(enemy => enemy.activeSelf == false) != 0)
            {
                foreach (var enemy in activeEnemies)
                {
                    enemyPool.ReturnToPool(enemy);
                    
                }

                activeEnemies = null;
                _enemiesCount = waves[_currentWaveIndex].EnemySettings.Length;
                Debug.Log("next");
                EnemiesInWave = 0;
                LaunchNextWave();
            }
            
        }

        private void LaunchNextWave()
        {
            StartCoroutine(EnemiesSpawn());
        }
        private IEnumerator EnemiesSpawn()
        {
            activeEnemies = new List<GameObject>();
                for (int i = 0; i < _enemiesCount; i++)
                {
                    yield return new WaitForSeconds(waves[_currentWaveIndex]
                        .EnemySettings[i]
                        .SpawnDelay);
                    enemyPool.TryGetFromPool(out GameObject enemyInstance);
                    var enemy = enemyPool.Enemies[enemyInstance];
                    enemy.Init(waves[_currentWaveIndex].EnemySettings[i].EnemyData);
                    enemy.transform.position = waves[_currentWaveIndex].EnemySettings[i].SpawnPoint.transform.position;
                    EnemiesInWave++;
                    activeEnemies.Add(enemyInstance);
                    Debug.Log(EnemiesInWave);
                }

                _currentWaveIndex++;


        }

        /*private void ChangeValue(int val)
        {
            EnemiesInWave += val;
            Debug.Log(EnemiesInWave);
            if (EnemiesInWave == 0 && _currentWaveIndex < waves.Length - 1)
            {
                _currentWaveIndex++;
                LaunchNextWave();
            }
        }*/
        
            
        
    }
}
