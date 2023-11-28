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
        [SerializeField] private float health;
        public float Health => health;
        [SerializeField] private float magicArmor;
        public float MagicArmor => magicArmor;
        [SerializeField] private float physicArmor;
        public float PhysicArmor => physicArmor;
        [SerializeField] private float gold;
        public float Gold => gold;
    }
}
