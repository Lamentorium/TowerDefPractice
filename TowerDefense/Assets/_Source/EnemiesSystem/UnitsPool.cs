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
        [field: SerializeField] public int MaximumWavePoolSize { get; private set; }
        //[SerializeField] private List<EnemySettings> enemySettings;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject parent;
        //public List<EnemySettings> EnemySettings => enemySettings;
        public Dictionary<GameObject, Enemy> Enemies { get; private set; }
        private Queue<GameObject> _enemies;
        
        public void InitPool()
        {
           
            
            _enemies = new Queue<GameObject>();
            Enemies = new Dictionary<GameObject, Enemy>();
            for (int i = 0; i < MaximumWavePoolSize; i++)
            {
                
                GameObject enemyInstance = GameObject.Instantiate(enemyPrefab, parent.transform);
                if(enemyInstance.TryGetComponent(out Enemy enemyScript))
                    Enemies.Add(enemyInstance, enemyScript );
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
