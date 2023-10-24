using UnityEngine;

namespace EnemiesSystem.Data
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        private EnemyDataSO _enemyData;
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public int Armor { get; set; }


        public void Init(EnemyDataSO enemyData)
        {
            _enemyData = enemyData;
            if(TryGetComponent(out SpriteRenderer enemySprite))
                enemySprite.sprite = _enemyData.Sprite;

        }
    
    }
}
