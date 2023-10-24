using System;
using System.Collections;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    public class WavesSpawner : MonoBehaviour
    {
        [SerializeField] private Waves[] waves;
        [SerializeField] private float delayBetweenWaves;
        
        public static int EnemiesInWave { get; set; }
        private int _currentWaveIndex;


        private void Start()
        {
            
            Init();
            LaunchNextWave();
            
        }

        private void OnEnable()
        {
            TestWaveSystem.Action += ChangeValue;
        }

        private void OnDisable()
        {
            TestWaveSystem.Action -= ChangeValue;
        }

        private void Init()
        {
            for (int i = 0; i < waves.Length; i++)
            {
                
                
            }

        }

        private void LaunchNextWave()
        {
            StartCoroutine(EnemiesSpawn());
        }
        private IEnumerator EnemiesSpawn()
        {
            if(waves[_currentWaveIndex].EnemiesPool.PoolSize == 0)
                waves[_currentWaveIndex].EnemiesPool.InitPool();
            if (EnemiesInWave < waves[_currentWaveIndex].EnemiesPool.PoolSize && EnemiesInWave == 0)
            {
                
                for (int i = 0; i < waves[_currentWaveIndex].EnemiesPool.PoolSize; i++)
                {
                    yield return new WaitForSeconds(waves[_currentWaveIndex]
                        .EnemiesPool.EnemySettings[i]
                        .SpawnDelay);
                    waves[_currentWaveIndex].EnemiesPool.TryGetFromPool(out GameObject enemyInstance);
                    EnemiesInWave++;
                    Debug.Log(EnemiesInWave);
                }
                
            }
            
        }

        private void ChangeValue(int val)
        {
            EnemiesInWave += val;
            Debug.Log(EnemiesInWave);
            if (EnemiesInWave == 0 && _currentWaveIndex < waves.Length - 1)
            {
                _currentWaveIndex++;
                LaunchNextWave();
            }
        }
        
            
        
    }
}
