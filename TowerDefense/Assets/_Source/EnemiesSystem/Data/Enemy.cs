using System;
using System.Collections;
using BaseSys;
using EconomySystem;
using EnemiesSystem.WavesSystem;
using UnityEngine;
using UnityEngine.AI;

namespace EnemiesSystem.Data
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        private EnemyDataSO _enemyData;
        public Action OnHit;
        public float Health { get; set; }
        
        public float MaxHealth { get; set; }
        public float MagicArmor { get; set; }
        public float PhysicArmor { get; set; }
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float baseSpeed;

        public float GoldCount { get; set; }
        public Action TakeDamage;

        public void Init(EnemyDataSO enemyData)
        {
            _enemyData = enemyData;
            if (TryGetComponent(out SpriteRenderer enemySprite))
                enemySprite.sprite = _enemyData.Sprite;
            Health = enemyData.Health;
            MaxHealth = Health;
            MagicArmor = enemyData.MagicArmor;
            PhysicArmor = enemyData.PhysicArmor;
            Speed = enemyData.Speed;
            baseSpeed = enemyData.Speed;
            GoldCount = enemyData.Gold;
            Damage = enemyData.Damage;
        }

        public void Slowed(float slow, float slowtime)
        {
            Speed = baseSpeed * slow;

            StartCoroutine(ResetSpeed(slowtime));
        }
        private IEnumerator ResetSpeed(float slowtime)
        {
            yield return new WaitForSeconds(slowtime);
            Speed = baseSpeed;

        }
        public void DamgeRecieved(float dmg, bool isMagic)
        {
            Debug.Log("dmg taken");
            if (isMagic == true)
            {
                Debug.Log("Magic resisted");
                Health -= dmg - (dmg * MagicArmor);
            }
            else
            {
                Debug.Log("Physical resisted");
                Health -= dmg - (dmg * PhysicArmor);
                Debug.Log("Physical resisted");
            }
            Debug.Log("Health: " + Health);
            TakeDamage?.Invoke();
            OnHit?.Invoke();
            if (Health <= 0)
            {
                //Gold.AddGold(GoldCount);
                LevelManager.main.IncreaseCurrency(GoldCount);
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            //BaseHealth attackedbase = other.collider.GetComponent<BaseHealth>();
            //GetComponent тяжелая операция, лучше никогда не использовать, TryGetComponent лучше

            if (other.gameObject.TryGetComponent(out BaseHealth attackedbase))
            {
                Debug.Log("attack base");
                attackedbase.TakeDamage(Damage); 
                //Destroy(gameObject);
                gameObject.SetActive(false);
                
            }
            
            
        }
    }
}
