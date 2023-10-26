using DG.Tweening;
using EnemiesSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace EnemiesSystem.HpSystem
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBarImage;
        [SerializeField] private Canvas healthBar;
        public Canvas HealthBar => healthBar;
         private Enemy _enemy;
    
        //TODO консультация по поводу TryGetComp
 

        private void OnEnable()
        {
            TryGetComponent(out Enemy enemy);
            healthBarImage.fillAmount = 1;
            healthBarImage.color = Color.green;
            _enemy = enemy;
            _enemy.TakeDamage += UpdateHealthBar;

        }

        private void OnDisable()
        {
            _enemy.TakeDamage -= UpdateHealthBar;
        }

  

        public void UpdateHealthBar()
        {
            float duration = 0.75f * (_enemy.Health / _enemy.MaxHealth);
            float num = _enemy.Health / _enemy.MaxHealth;
            Debug.Log(num);
            healthBarImage.DOFillAmount( num, duration );
            Color newColor = Color.green;
            if ( _enemy.Health < _enemy.MaxHealth * 0.25f ) {
                newColor = Color.red;
            } else if ( _enemy.Health < _enemy.MaxHealth * 0.66f ) {
                newColor = new Color( 1f, .64f, 0f, 1f );
            }
                
            healthBarImage.DOColor( newColor, duration );
        }
    }
}
