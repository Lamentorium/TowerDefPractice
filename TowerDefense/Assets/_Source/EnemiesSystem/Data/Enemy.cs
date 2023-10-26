using System;
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
         public Action TakeDamage;
         [SerializeField] private GameObject target;
         private NavMeshAgent agent;

         private void Start()
         {
             agent = GetComponent<NavMeshAgent>();
             agent.updateRotation = false;
             agent.updateUpAxis = false;
         }

         private void Update()
         {
             agent.SetDestination(target.transform.position);
         }

         public void Init(EnemyDataSO enemyData)
        {
            _enemyData = enemyData;
            if(TryGetComponent(out SpriteRenderer enemySprite))
                enemySprite.sprite = _enemyData.Sprite;
            Health = enemyData.Health;
            MaxHealth = Health;
            MagicArmor = enemyData.MagicArmor;
            PhysicArmor = enemyData.PhysicArmor;
        }

         private void OnTriggerEnter2D(Collider2D col)
         {
             Health -= 20;
             TakeDamage?.Invoke();
             if(Health <= 0)
                 gameObject.SetActive(false);
             
         }
    }
}
