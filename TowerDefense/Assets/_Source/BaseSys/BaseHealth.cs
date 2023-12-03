using System;
using TMPro;
using UnityEngine;

namespace BaseSys
{
    public class BaseHealth : MonoBehaviour
    {
        [field: SerializeField] public float Health { get; private set; }
        
        public Action<float> TakeDmg;
        public Action GameOver;

        public void TakeDamage(float dmg)
        {
            Health -= dmg;
            TakeDmg?.Invoke(Health);
            if (Health <= 0)
            {
                GameOver?.Invoke();
            }
        }
       

    }
}
