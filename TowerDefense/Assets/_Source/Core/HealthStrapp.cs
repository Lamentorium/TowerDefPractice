using System;
using BaseSys;
using EconomySystem;
using EnemiesSystem.WavesSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class HealthStrapp : MonoBehaviour
    {
        [SerializeField] private BaseHealthView baseHealthView;
        [SerializeField] private BaseHealth baseHealth;
       
        private void Awake()
        {
           baseHealthView.Construct(baseHealth);
        }
    }
}