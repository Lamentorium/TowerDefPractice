using UnityEngine;

namespace EnemiesSystem.Data
{
    [CreateAssetMenu(fileName = "NewEnemyDataSO", menuName = "SO/New Enemy Data")]
    public class EnemyDataSO : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
        [SerializeField] private float speed;
        public float Speed => speed;
        [SerializeField] private int damage;
        public int Damage => damage;
        [SerializeField] private int health;
        public int Health => health;
        [SerializeField] private int magicArmor;
        public int MagicArmor => magicArmor;
        [SerializeField] private int physicArmor;
        public int PhysicArmor => physicArmor;
        
    }
}
