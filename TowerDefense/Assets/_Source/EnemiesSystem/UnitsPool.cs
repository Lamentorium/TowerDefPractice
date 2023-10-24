using System;
using System.Collections.Generic;
using EnemiesSystem.Data;
using EnemiesSystem.WavesSystem;
using UnityEngine;

namespace EnemiesSystem
{
    [Serializable]
    
    public class UnitsPool
    {
        [field: SerializeField] public int PoolSize { get; private set; }
        [SerializeField] private List<EnemySettings> enemySettings;
        [SerializeField] private GameObject parent;
        public List<EnemySettings> EnemySettings => enemySettings;
        
        

        private Queue<GameObject> _enemies;

        public void InitPool()
        {
           
            PoolSize = enemySettings.Count;
            _enemies = new Queue<GameObject>();
            for (int i = 0; i < PoolSize; i++)
            {
                if (enemySettings[i].EnemyPrefab.TryGetComponent(out Enemy enemy))
                    enemySettings[i].Construct(enemy);
                


                
                GameObject enemyInstance = GameObject.Instantiate(enemySettings[i].EnemyPrefab, enemySettings[i].SpawnPoint.transform.position, Quaternion.identity, parent.transform);
                ReturnToPool(enemyInstance);
            }
        }

        public bool TryGetFromPool(out GameObject enemyInstance)
        {
            enemyInstance = null;
            if (_enemies.Count > 0)
            {
                enemyInstance = _enemies.Peek();
                enemyInstance.SetActive(true);
                enemyInstance = _enemies.Dequeue();
                return true;
            }

            return false;
        }

        public void ReturnToPool(GameObject enemyInstance)
        { 
            enemyInstance.SetActive(false);
            _enemies.Enqueue(enemyInstance);
        }
    }
}
