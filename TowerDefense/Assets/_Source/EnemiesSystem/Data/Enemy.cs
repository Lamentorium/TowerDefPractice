using System;
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
         public float Health { get; set; }
         public float MaxHealth { get; set; }
         public float MagicArmor { get; set; }
         public float PhysicArmor { get; set; }
         public float Speed { get; set; }
         
         public float GoldCount { get; set; }
         public Action TakeDamage;
         
         public void Init(EnemyDataSO enemyData)
        {
            _enemyData = enemyData;
            if(TryGetComponent(out SpriteRenderer enemySprite))
                enemySprite.sprite = _enemyData.Sprite;
            Health = enemyData.Health;
            MaxHealth = Health;
            MagicArmor = enemyData.MagicArmor;
            PhysicArmor = enemyData.PhysicArmor;
            Speed = enemyData.Speed;
            GoldCount = enemyData.Gold;
        }

         public void DamgeRecieved(int dmg)
         {
            Debug.Log("dmg taken");
             Health -= dmg;
             TakeDamage?.Invoke();
             if (Health <= 0)
             {
                 Gold.AddGold(GoldCount);
                 gameObject.SetActive(false);
             }
             
         }
    }
}
