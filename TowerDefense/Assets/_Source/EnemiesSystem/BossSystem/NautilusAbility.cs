using System;
using System.Collections;
using System.Collections.Generic;
using EnemiesSystem.Data;
using EnemiesSystem.EnemyMovement;
using UnityEngine;

namespace EnemiesSystem.BossSystem
{
    public class NautilusAbility : MonoBehaviour, INautilusAbility
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemyDataSO enemyDataSo;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform[] destinationPoints;
        [SerializeField] private float speedMultiplier;
        [SerializeField] private float timeOfExtraSpeed;
        [SerializeField] private float delayBetweenSpawns;
        private Enemy _enemyScript;
        public Action OnAbility { get; private set; }


        private void OnEnable()
        {
            if (TryGetComponent(out Enemy enemyScript))
            {
                _enemyScript = enemyScript;
                _enemyScript.OnHit += CheckDmg;
                OnAbility = CheckDmgOn3000;

            }
        }
        public void CheckDmg()
        {
            if (_enemyScript.Health <= 3000)
            {
                if (OnAbility == CheckDmgOn3000)
                {
                    OnAbility?.Invoke();
                    OnAbility -= CheckDmgOn3000;
                    OnAbility += CheckDmgOn2000;
                }
               
            }
            if (_enemyScript.Health <= 2000)
            {
                if (OnAbility == CheckDmgOn2000)
                {
                    OnAbility?.Invoke();
                    OnAbility -= CheckDmgOn2000;
                    OnAbility += CheckDmgOn1000;
                }
               
            }

            if (_enemyScript.Health <= 1000)
            {
                if (OnAbility == CheckDmgOn1000)
                {
                   
                    OnAbility?.Invoke();
                    OnAbility -= CheckDmgOn1000;
                }
            }
        }

        public void CheckDmgOn1000()
        {
            StartCoroutine(AbilityActivator());
        }

        public void CheckDmgOn2000()
        {
            StartCoroutine(AbilityActivator());
        }

        public void CheckDmgOn3000()
        {
            StartCoroutine(AbilityActivator());
        }
        public IEnumerator AbilityActivator()
        {
            Debug.Log("Ability activated");
            var temp1 = _enemyScript.Speed;
            _enemyScript.Speed *= speedMultiplier;
            yield return new WaitForSeconds(timeOfExtraSpeed);
            StartCoroutine(EnemySpawn());
            _enemyScript.Speed = temp1;

        }

        private IEnumerator EnemySpawn()
        {
            for (int i = 0; i < 2; i++)
            {
                
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.TryGetComponent(out Enemy enemyScipt);
                enemyScipt.Init(enemyDataSo);
                enemyScipt.TryGetComponent(out Movement enemyMove);
                enemyMove.enabled = true;
                enemyMove.Init(destinationPoints, enemy.transform);

                yield return new WaitForSeconds(delayBetweenSpawns);
            }
        }
        
        
    }
}
