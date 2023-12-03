using System;
using BaseSys;
using EconomySystem;
using EnemiesSystem.WavesSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private WavesSpawner wavesSpawner;
        [SerializeField] private BaseHealthView baseHealthView;
        [SerializeField] private BaseHealth baseHealth;
       
        private void Awake()
        {
            wavesSpawner.Construct();
            baseHealthView.Construct(baseHealth);
            
        }
    }
}
