using System;
using System.Collections;
using System.Collections.Generic;
using EnemiesSystem.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemiesSystem.BossSystem
{
    public class DonKihotAbility : MonoBehaviour, IDonKihotAbility
    {
        [SerializeField] private float timeOfStop;
        [SerializeField] private LayerMask towerMask;
        [SerializeField] private float findTowerRange = 8f;
        private Enemy _enemyScript;
        public Action OnAbility { get; private set; }
        private List<Transform> _towers;
        private bool _towersDisabled = false;
        private int _clicks = 0;
        private void OnEnable()
        {
            if (TryGetComponent(out Enemy enemyScript))
            {
                _enemyScript = enemyScript;
                _enemyScript.OnHit += CheckDmg;
                OnAbility = CheckDmgOn2000;
                _towersDisabled = false;
                _towers = new();
            }
        }

        private void Update()
        {
            if (_towersDisabled == true)
            {
                ClickTimeEvent();
            }
        }

        public void CheckDmg()
        {
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
        public void CheckDmgOn2000()
        {
            
                StartCoroutine(AbilityActivator());
            

            
        }
        public void CheckDmgOn1000()
        {
             
                
                StartCoroutine(AbilityActivator());
            
        }

        public IEnumerator AbilityActivator()
        {
            Debug.Log("Ability activated");
            var temp1 = _enemyScript.Speed;
            _enemyScript.Speed = 0;
            SwitchOffTowers();
            _towersDisabled = true;
            yield return new WaitForSeconds(timeOfStop);
            _enemyScript.Speed = temp1;
           
           
            
        }

        private void SwitchOffTowers()
        {
            FindTowers();
        }
        private void FindTowers()
        {
            Debug.Log("Find towers");
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, findTowerRange, (Vector2)transform.position, 0f, towerMask);

            if (hits.Length > 0)
            {
                Debug.Log("Found hit");
                for (int i = 0; i < hits.Length; ++i)
                {
                    if(hits[i].transform.gameObject.TryGetComponent(out AOETower aoeTower))
                    { 
                        Debug.Log("Found");
                        aoeTower.enabled = false;
                        _towers.Add(hits[i].transform);
                    }
                    if(hits[i].transform.gameObject.TryGetComponent(out SlowTower slowTower))
                    { 
                        Debug.Log("Found");
                        slowTower.enabled = false;
                        _towers.Add(hits[i].transform);
                    }
                    if(hits[i].transform.gameObject.TryGetComponent(out Tower tower))
                    { 
                        Debug.Log("Found");
                        tower.enabled = false;
                        _towers.Add(hits[i].transform);
                    }
                    else
                    {
                        
                        Debug.Log("Nothing Found");
                    }
                }
            }
        }

        private void ClickTimeEvent()
        {
            _towersDisabled = true;
            if (_clicks == 5)
            {
                SwitchOnTowers();
                _towersDisabled = false;
                _clicks = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _clicks++;
            }
        }

        private void SwitchOnTowers()
        {

            for (int i = 0; i < _towers.Count; i++)
            {
                
                if (_towers[i].gameObject.TryGetComponent(out AOETower aoeTower))
                {

                    aoeTower.enabled = true;
                   
                }

                if (_towers[i].gameObject.TryGetComponent(out SlowTower slowTower))
                {

                    slowTower.enabled = true;
                    
                }

                if (_towers[i].gameObject.TryGetComponent(out Tower tower1))
                {

                    tower1.enabled = true;
                    
                }
            }
                _towers.Clear();

            _towersDisabled = false;
            _clicks = 0;
                
                
            }

        
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, transform.forward, findTowerRange);
        }
    }
}
